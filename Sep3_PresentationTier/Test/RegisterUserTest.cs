using BlazorServerApp.Pages;
using Bunit;
using Domains.Entity;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test;

public class RegisterUserTest : IClassFixture<TestContext>
{
    private TestContext context;
    private IRenderedComponent<RegisterUser> renderedComponent;
    private Mock<IUserService> userService;


    private void Setup() {
        HttpClient client = new HttpClient();
        userService = new Mock<IUserService>();
        context = new TestContext();
        context.Services.AddSingleton<IUserService>(new UserService(client));
        context.Services.AddSingleton<ICardService>(new CardService(client));
        context.Services.AddSingleton(userService.Object);
        context.Services.AddAuthorization();
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
        renderedComponent.Instance.ExpiryFullDate = DateTime.Today;
        renderedComponent.Instance.CVV = 741;
       
    }
    
    
    [Fact]
    public void ErrorMessageWhenFullnameIsNull()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.Name = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Full name Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
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
            "Error: Password Must Be More Than 6 Characters Long.",
            renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordAndRepeatPasswordDoesNotMatch()
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
    public async Task CreateAccount_ShouldThrowAnError_WhenCardNumberIsTenDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CardNumber = 1234567890;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: Card Number Must Be 16 Digits Long", renderedComponent.Instance.ErrorLabel);
    }

    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCardNumberIsFifteenDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CardNumber = 123456789012345;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: Card Number Must Be 16 Digits Long", renderedComponent.Instance.ErrorLabel);
    }
    
    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCardNumberIsSeventeenDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CardNumber = 12345678901234567;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: Card Number Must Be 16 Digits Long", renderedComponent.Instance.ErrorLabel);
    }
    
    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCVVIsZeroDigit() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CVV = 0;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: CVV Cannot Be Empty", renderedComponent.Instance.ErrorLabel);
    }
    
    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCVVIsTwoDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();    
        renderedComponent.Instance.CVV = 12;
        
        //Act
        await renderedComponent.Instance.CreateAsync();
        
        //Assert
        Assert.Equal("Error: CVV must be 3 digits long", renderedComponent.Instance.ErrorLabel);
    }


    [Fact]
    public async Task CreateAccount_ShouldThrowAnError_WhenCVVIsFourDigits() {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.CVV = 12;

        //Act
        await renderedComponent.Instance.CreateAsync();

        //Assert
        Assert.Equal("Error: CVV must be 3 digits long", renderedComponent.Instance.ErrorLabel);
    }
    
    [Fact]
    public async Task CreateAccount_ShouldNotThrowAnError_WhenAllFieldsAreEnteredCorrectly() {
        //Arrange
        Setup();
        // var name = renderedComponent.Instance.Name = "test";
        // var username = renderedComponent.Instance.Username = "test12";
        // var password = renderedComponent.Instance.Password = "Test@123";
        // var repeatPassword = renderedComponent.Instance.RepeatPassword = "Test@123";
        // var cardNumber = renderedComponent.Instance.CardNumber = 1234567890123456;
        // var expiryFullDate = renderedComponent.Instance.ExpiryFullDate = DateTime.Today;
        // string expiryDate = $"{expiryFullDate.Date.Month}/{expiryFullDate.Date.Year}";
        // var cvv = renderedComponent.Instance.CVV = 741;
        SetInstancesValueForUser();
        
        renderedComponent.Instance.GoToStep2();
        SetInstancesValueForDebitCard();
        
        // if (cardNumber == 0) throw new Exception("Card Number Cannot Be Empty");
        // if (cardNumber.ToString().Length != 16) throw new Exception("Card Number Must Be 16 Digits Long");
        // if (string.IsNullOrEmpty(expiryDate)) throw new Exception("ExpiryDate Cannot Be Empty");
        // if (cvv == 0) throw new Exception("CVV Cannot Be Empty");
        // if (cvv.ToString().Length != 3) throw new Exception("CVV must be 3 digits long");
        // DebitCardEntity cardEntity = new DebitCardEntity(cardNumber, expiryDate, cvv);
        // UserEntity userEntity = new UserEntity(name, username, password, cardEntity,1000);
        
        //Act
        // await userService.Object.CreateAsync(userEntity);
        await renderedComponent.Instance.CreateAsync();
        //Assert
        // Assert.Null(renderedComponent.Instance.ErrorLabel);
        Assert.Equal("User test12 successfully created", renderedComponent.Instance.ErrorLabel);
    }

}