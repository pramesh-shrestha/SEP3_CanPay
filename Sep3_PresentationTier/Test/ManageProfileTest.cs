using System.Security.Claims;
using BlazorServerApp.Pages;

using Bunit;
using Bunit.TestDoubles;
using HTTPClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test;

public class ManageProfileTest : TestContext
{
    private readonly IRenderedComponent<ManageProfile> renderedComponent;

    public ManageProfileTest()
    {
        Mock<IUserService> userServiceMock = new Mock<IUserService>();
        Mock<ICardService> cardServiceMock = new Mock<ICardService>();
        Mock<AuthenticationStateProvider> stateProvider = new();
        var context = new TestContext();

        var authorizationContext = this.AddTestAuthorization();
        authorizationContext.SetAuthorized("test");

        // creating sample authentication state with user claim
        List<Claim> claims = new List<Claim>
        {
            new Claim("username", "test"),
        };

        var authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
        stateProvider.Setup(provider => provider.GetAuthenticationStateAsync()).ReturnsAsync(authenticationState);
        
        context.Services.AddSingleton(userServiceMock.Object);
        context.Services.AddSingleton(cardServiceMock.Object);
        context.Services.AddAuthorization();

        renderedComponent = context.RenderComponent<ManageProfile>();
    }

    private void Setup()
    {
    }

    private void SetInstancesValueForUser()
    {
        //renderedComponent.Instance.password 
        renderedComponent.Instance.currentPassword = "currentPassword";
        renderedComponent.Instance.newPassword = "newPassword";
        renderedComponent.Instance.confirmNewPassword = "newPassword";
    }

    private void SetInstancesValueForDebitCard()
    {
        renderedComponent.Instance.fullName = "fullName";
        renderedComponent.Instance.cardNumber = 1234567890123456;
        renderedComponent.Instance.expiryDate = ("22/12/2026");
        renderedComponent.Instance.cvv = 888;
    }

    [Fact]
    public void ErrorMessageWhenPasswordIsEmpty_EditButton()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.currentPassword = "";

        Assert.Equal("You must enter your current password.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenNewPasswordIsEmpty_Popup()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.newPassword = "";
        renderedComponent.Instance.Proceed();

        Assert.Equal("All fields required!", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenNewPasswordConfirmIsEmpty_Popup()
    {
        Setup();
        SetInstancesValueForUser();
        renderedComponent.Instance.confirmNewPassword = "";
        renderedComponent.Instance.Proceed();

        Assert.Equal("All fields required!", renderedComponent.Instance.errorLabel);
    }


    [Fact]
    public void ErrorMessageWhenPasswordsMismatch()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.confirmNewPassword = "newPasswordMismatch";
        renderedComponent.Instance.Proceed();

        Assert.Equal("New password mismatch!", renderedComponent.Instance.errorLabel);
    }


    [Fact]
    public void ErrorMessageWhenPasswordIs5CharactersLong()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.newPassword = "12345";
        renderedComponent.Instance.confirmNewPassword = "12345";
        renderedComponent.Instance.Proceed();

        Assert.Equal(
            "Password Must Be 6 Characters Long.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public void ErrorMessageWhenNewPasswordEqualsCurrentPassword()
    {
        Setup();
        SetInstancesValueForUser();

        renderedComponent.Instance.newPassword = "currentPassword";
        renderedComponent.Instance.confirmNewPassword = "currentPassword";
        renderedComponent.Instance.Proceed();

        Assert.Equal("You must enter new password different from your current password.",
            renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenFullNameIsNull()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.fullName = "";

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Fullname or Expiry Date Fields Cannot Be Left Empty.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenExpiryDateIsNull()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.fullName = "";

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Fullname or Expiry Date Fields Cannot Be Left Empty.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCardNumberIsZero()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cardNumber = 0;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Card Number Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCardNumberIsTenDigits()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cardNumber = 1234567890;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Card Number Must Be 16 Digits Long", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCardNumberIsSeventeenDigits()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cardNumber = 12345678901234567;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Card Number Must Be 16 Digits Long", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCVVIsZeroDigit()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cvv = 0;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("CVV Cannot Be Empty", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCVVIsTwoDigits()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cvv = 12;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("CVV must be 3 digits long", renderedComponent.Instance.errorLabel);
    }


    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenCVVIsFourDigits()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.cvv = 1234;

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("CVV must be 3 digits long", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenYearIs2012()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.expiryDate = ("22/12/2012");

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Invalid Date", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task SaveChanges_ShouldThrowAnError_WhenYearIs3000()
    {
        //Arrange
        Setup();
        SetInstancesValueForDebitCard();
        renderedComponent.Instance.expiryDate = ("22/12/3000");

        //Act
        await renderedComponent.Instance.GetErrorMessage();

        //Assert
        Assert.Equal("Invalid Date", renderedComponent.Instance.errorLabel);
    }
}
