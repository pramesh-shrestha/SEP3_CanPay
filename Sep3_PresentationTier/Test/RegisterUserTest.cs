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

    private void Setup()
    {
        context = new TestContext();
        context.Services.AddSingleton<IUserService>(new UserService(new HttpClient()));

        renderedComponent = context.RenderComponent<RegisterUser>();
        
    }

    private void SetInstancesValue()
    {
        renderedComponent.Instance.name = "test";
        renderedComponent.Instance.username = "test12";
        renderedComponent.Instance.password = "Test@123";
        renderedComponent.Instance.repeatPassword = "Test@123";
    }

    [Fact]
    public void ErrorMessageWhenFullNameIsNull()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.name = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Full Name Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenUsernameIsNull()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.username = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Username Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordIsNull()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.password = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Password Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenRepeatPasswordIsNull()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.repeatPassword = "";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Repeat Password Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordIs6CharactersLong()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.password = "12345";
        renderedComponent.Instance.repeatPassword = "12345";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal(
            "Error: Password Must Be Between 8 and 30 Characters Long. Must Have 1 symbol and 1 capital letter",
            renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenPasswordAndRepeatPasswordDoesnotMatch()
    {
        Setup();
        SetInstancesValue();

        renderedComponent.Instance.password = "Test@123";
        renderedComponent.Instance.repeatPassword = "Test@1234";
        renderedComponent.Instance.GoToStep2();

        Assert.Equal("Error: Password and Repeat Password doesn't match!!", renderedComponent.Instance.errorLabel);
    }
}