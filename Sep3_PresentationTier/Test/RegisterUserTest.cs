using BlazorServerApp.Pages;
using Bunit;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Test;

public class RegisterUserTest : IClassFixture<TestContext>
{
    
    private TestContext context;
    private IRenderedComponent<RegisterUser> renderedComponent;
 

    private void Setup() {
        HttpClient client = new HttpClient();
        context = new TestContext();
        context.Services.AddSingleton<IUserService>(new UserService(client));
        context.Services.AddSingleton<ICardService>(new CardService(client));

        renderedComponent = context.RenderComponent<RegisterUser>();
        
    }

    private void SetInstancesValueForUser()
    {
        renderedComponent.Instance.Name = "test";
        renderedComponent.Instance.Username = "test12";
        renderedComponent.Instance.Password = "Test@123";
        renderedComponent.Instance.RepeatPassword = "Test@123";
    }
    
    private void SetInstancesValueForDebitCard() {
        renderedComponent.Instance.CardNumber = 1234567890123456;
        renderedComponent.Instance.ExpiryFullDate = DateTime.Parse("22/12/2026");
        renderedComponent.Instance.CVV = 741;
       
    }
    
    
    [Fact]
    public void ErrorMessageWhenFullNameIsNull()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Name = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Full Name Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenUsernameIsNull()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Username = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Username Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordIsNull()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Password = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Password Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenRepeatPasswordIsNull()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.RepeatPassword = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Repeat Password Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordIs6CharactersLong()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Password = "12345";
        renderedComponent.Instance.RepeatPassword = "12345";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal(
            "Error: Password Must Be Between 8 and 30 Characters Long. Must Have 1 symbol and 1 capital letter",
            renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordAndRepeatPasswordDoesnotMatch()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Password = "Test@123";
        renderedComponent.Instance.RepeatPassword = "Test@1234";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Password and Repeat Password doesn't match!!", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCardNumberIsZero() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CardNumber = 0;
        
        //Act
        await renderedComponent.Instance.CreateAsync();

        //Assert
        Assert.Equal("Error: Card Number Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCarNumberIsTenDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CardNumber = 1234567890;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: Card Number Must Be 16 Digits Long", renderedComponent.Instance.ErrorLabel);

    }
}