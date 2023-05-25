using System.Security.Claims;
using BlazorServerApp.Pages;
using Bunit;
using Bunit.TestDoubles;
using Domains.Entity;
using HTTPClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test;

public class BillPaymentPageTest : TestContext
{
    private readonly Mock<IBillPaymentService> billPaymentServiceMock;
    private readonly UserEntity? currentUser;
    private BillPaymentEntity? expectedBillPayment;
    private readonly Billpayments instance;

    public BillPaymentPageTest()
    {
        billPaymentServiceMock = new Mock<IBillPaymentService>();
        Mock<IUserService> userServiceMock = new();
        Mock<AuthenticationStateProvider> stateProvider = new();
        var context = new TestContext();
   

        // creating sample authentication state with user claim
        List<Claim> claims = new List<Claim>
        {
            new Claim("username", "test"),
        };

        var authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
        stateProvider.Setup(provider => provider.GetAuthenticationStateAsync()).ReturnsAsync(authenticationState);

        // creating sample user
        currentUser = new UserEntity
        {
            UserId = 1,
            FullName = "Test User",
            UserName = "test",
            Password = "password",
            Balance = 1000,
            Card = new DebitCardEntity()
        };


        // registering the mock services
        context.Services.AddSingleton(billPaymentServiceMock.Object);
        context.Services.AddSingleton(userServiceMock.Object);
        context.Services.AddSingleton(stateProvider.Object);
        context.Services.AddAuthorization();

        IRenderedComponent<Billpayments> renderedComponent = context.RenderComponent<Billpayments>();
        instance = renderedComponent.Instance;
    }

    private void SetInstanceValues()
    {
        instance.payee = "ABC Company";
        instance.accountNumber = "1234567890";
        instance.amount = "100";

        expectedBillPayment = new BillPaymentEntity()
        {
            Payer = currentUser,
            Payee = instance.payee,
            AccountNumber = instance.accountNumber,
            Date = "2023/05/24",
            Amount = 100,
            ReferenceNumber = "ReferenceId - 101"
        };
    }

    [Fact]
    public async Task PayBill_ValidInput_CreatesBillPaymentAndSetsShowModalToTrue()
    {
        //Arrange
        SetInstanceValues();

        //Act
        await instance.PayBill();

        //Assert
        Assert.True(instance.showModal);
        Assert.Equal("Bill Payment Successfully Made!", instance.errorLabel);
    }

    [Fact]
    public async Task PayBill_PayeeIsEmpty_ThrowsException()
    {
        //Arrange
        SetInstanceValues();
        instance.payee = "";

        //Act
        await instance.PayBill();

        //Assert
        Assert.False(instance.showModal);
        Assert.Equal("payee name must be filled in", instance.errorLabel);
        billPaymentServiceMock.Verify(service => service.CreateAsync(expectedBillPayment), Times.Never);
    }

    [Fact]
    public async Task PayBill_AccountNumberIsZero_ThrowsException()
    {
        //Arrange
        SetInstanceValues();
        instance.accountNumber = "0";

        //Act
        await instance.PayBill();

        //Assert
        Assert.False(instance.showModal);
        Assert.Equal("Account number must be of 10 digits", instance.errorLabel);
        billPaymentServiceMock.Verify(service => service.CreateAsync(expectedBillPayment), Times.Never);
    }

    [Fact]
    public async Task PayBill_AccountNumberLengthEqualToNine_ThrowsException()
    {
        //Arrange
        SetInstanceValues();
        instance.accountNumber = "123456789";

        //Act
        await instance.PayBill();

        //Assert
        Assert.False(instance.showModal);
        Assert.Equal("Account number must be of 10 digits", instance.errorLabel);
        billPaymentServiceMock.Verify(service => service.CreateAsync(expectedBillPayment), Times.Never);
    }
    
    [Fact]
    public async Task PayBill_AmountLessThanZero_ThrowsException()
    {
        //Arrange
        SetInstanceValues();
        instance.amount = "0";

        //Act
        await instance.PayBill();

        //Assert
        Assert.False(instance.showModal);
        Assert.Equal("Amount must be more than 0.", instance.errorLabel);
        billPaymentServiceMock.Verify(service => service.CreateAsync(expectedBillPayment), Times.Never);
    }
}