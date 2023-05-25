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
        private Mock<ITransactionService> transactionService;
        private Mock<TransferValues> transferValues;
        private Mock<IRequestService> requestService;
        private Mock<INotificationService> notificationService;
        private Mock<AuthenticationStateProvider> stateProvider = new();

        private void Setup()
        {
            // creating sample authentication state with user claim
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", "test"),
            };

            var authenticationState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
            stateProvider.Setup(provider => provider.GetAuthenticationStateAsync()).ReturnsAsync(authenticationState);
            
            transactionService = new Mock<ITransactionService>();
            notificationService = new Mock<INotificationService>();
            requestService = new Mock<IRequestService>();
            notificationService = new Mock<INotificationService>();
            var client = new HttpClient();
            var userService = new Mock<IUserService>();
            transferValues = new Mock<TransferValues>();
            context = new TestContext();
            context.Services.AddSingleton(transactionService.Object);
            context.Services.AddSingleton(userService.Object);
            context.Services.AddSingleton<ICardService>(new CardService(client));
            context.Services.AddSingleton(notificationService.Object);
            context.Services.AddSingleton(transferValues.Object);
            context.Services.AddSingleton(requestService.Object);
            context.Services.AddAuthorization();
            
            // renderedComponent = context.RenderComponent<SendMoney>(parameters => parameters.AddSingleton<ITransactionService>(transactionService.Object));
            renderedComponent = context.RenderComponent<SendMoney>();
        }

        private void SetInstancesValue()
        {
            renderedComponent.Instance.sender = "Saran";
            renderedComponent.Instance.receiver = "Kevin";
            renderedComponent.Instance.amount = "100";
            renderedComponent.Instance.dateTime = DateTime.Today;
            renderedComponent.Instance.comment = "test";
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