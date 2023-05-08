using BlazorServerApp.Pages;
using Bunit;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test; 

public class LoginTest : IClassFixture<TestContext> {

    private TestContext context;
    private IRenderedComponent<Login> renderedComponent;
    private Mock<IUserService> userService;

    private void Setup() {
        userService = new Mock<IUserService>();
        context = new TestContext();
        context.Services.AddSingleton<IUserService>(new UserService(new HttpClient()));
        renderedComponent = context.RenderComponent<Login>();
    }

    private void SetInstancesValue() {
        renderedComponent.Instance.username = "test";
        renderedComponent.Instance.password = "Password1@";
    }

    [Fact]
    public async Task LoginAsync_ShouldThrowAnErrorMessage_WhenUsernameFieldIsEmpty() {
        //Arrange
        Setup();
        SetInstancesValue();
        renderedComponent.Instance.username = "";
        
        //Act
        await renderedComponent.Instance.GetErrorMessage();
        
        //Assert
        Assert.Equal("Error: Username cannot be empty", renderedComponent.Instance.errorLabel);
    }
    
    [Fact]
    public async Task  LoginAsync_ShouldThrowAnErrorMessage_WhenPasswordFieldIsEmpty() {
        //Arrange   
        Setup();
        SetInstancesValue();
        renderedComponent.Instance.password = "";
        
        //Act
        await renderedComponent.Instance.GetErrorMessage();
        
        //Assert
        Assert.Equal("Error: Password cannot be empty", renderedComponent.Instance.errorLabel);
    }
    
    [Fact]
    public async Task  LoginAsync_ShouldThrowAnErrorMessage_WhenBothFieldsAreEmpty() {
        //Arrange   
        Setup();
        renderedComponent.Instance.username = "";
        renderedComponent.Instance.password = "";
        
        //Act
        await renderedComponent.Instance.GetErrorMessage();
        
        //Assert
        Assert.Equal("Error: Both Username and Password are left blank", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task LoginAsync_ShouldNotThrowAnErrorMessage_WhnAllFieldsAreEnteredCorrectly() {
        //Arrange
        Setup();
        var username = renderedComponent.Instance.username = "test";
        var password = renderedComponent.Instance.password = "Password1@";
        
        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            throw new Exception("Both Username and Password are left blank");
        }
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("Username cannot be empty");
        }
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("Password cannot be empty");
        }
        
        //Act
        await userService.Object.ValidateUser(username, password);
        
        //Assert
        Assert.Null(renderedComponent.Instance.errorLabel);
    }
}