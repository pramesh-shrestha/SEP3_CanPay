using System.Security.Claims;
using BlazorServerApp.Pages;
using Bunit;
using Domains.Entity;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test
{
    public class TransactionTest : IClassFixture<TestContext>
    {
        private TestContext context;
        private IRenderedComponent<SendMoney> renderedComponent;
        private Mock<ITransactionService> transactionServiceMock;
        private Mock<TransferValues> transferValuesMock;
        private Mock<IRequestService> requestServiceMock;
        private Mock<INotificationService> notificationServiceMock;
        private Mock<AuthenticationStateProvider> stateProviderMock;
        private Mock<IUserService> userServiceMock;
        private UserEntity currentUser = new UserEntity();
        private UserEntity receiverUser = new UserEntity();


        private void Setup()
        {
            transactionServiceMock = new Mock<ITransactionService>();
            notificationServiceMock = new Mock<INotificationService>();
            requestServiceMock = new Mock<IRequestService>();
            notificationServiceMock = new Mock<INotificationService>();
            Mock<AuthenticationStateProvider> stateProviderMock = new();
            userServiceMock = new Mock<IUserService>();
            transferValuesMock = new Mock<TransferValues>();
            context = new TestContext();

            // creating sample authentication state with user claim
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", "test"),
            };

            var authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
            stateProviderMock.Setup(provider => provider.GetAuthenticationStateAsync())
                .ReturnsAsync(authenticationState);

            context.Services.AddSingleton(transferValuesMock.Object);
            context.Services.AddSingleton(transactionServiceMock.Object);
            context.Services.AddSingleton(notificationServiceMock.Object);
            context.Services.AddSingleton(requestServiceMock.Object);
            context.Services.AddSingleton(userServiceMock.Object);

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

            receiverUser = new UserEntity
            {
                UserId = 2,
                FullName = "Test User 2",
                UserName = "test2",
                Password = "password",
                Balance = 1000,
                Card = new DebitCardEntity()
            };


            renderedComponent = context.RenderComponent<SendMoney>();
        }

        private void SetInstancesValue()
        {
            renderedComponent.Instance.sender = "Saran";
            renderedComponent.Instance.receiver = "Kevin";
            renderedComponent.Instance.amount = "100";
            renderedComponent.Instance.dateTime = DateTime.Today;
            renderedComponent.Instance.comment = "test";

            NotificationEntity notificationEntity = new NotificationEntity
            {
                Date = DateTime.Today.ToString(),
                Sender = currentUser,
                Receiver = receiverUser,
                IsRead = false,
                Message = $"Transaction 1 Received: You received $100 CAD  from {currentUser.FullName}."
            };
        }


        [Fact]
        public async Task SendMoneyAsync_ValidInput_SetsShowModalToTrue()
        {
            Setup();
            SetInstancesValue();

            await renderedComponent.Instance.SendMoneyToReceiver();

            Assert.True(renderedComponent.Instance.showModal);
        }

        [Fact]
        public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenRecipientNameFieldIsEmpty()
        {
            //Arrange   
            Setup();
            SetInstancesValue();
            renderedComponent.Instance.receiver = "";

            //Act
            await renderedComponent.Instance.GetErrorMessage();

            //Assert
            Assert.Equal("Receiver must be selected.", renderedComponent.Instance.errorLabel);
        }

        [Fact]
        public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenAmountFieldIsZero()
        {
            //Arrange   
            Setup();
            SetInstancesValue();
            renderedComponent.Instance.amount = "0";

            //Act
            await renderedComponent.Instance.GetErrorMessage();

            //Assert
            Assert.Equal("Amount must be more than 0.", renderedComponent.Instance.errorLabel);
        }


        [Fact]
        public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenAmountIsNegative()
        {
            //Arrange   
            Setup();
            SetInstancesValue();
            renderedComponent.Instance.amount = "-100";

            //Act
            await renderedComponent.Instance.GetErrorMessage();

            //Assert
            Assert.Equal("Amount must be more than 0.", renderedComponent.Instance.errorLabel);
        }
    }
}