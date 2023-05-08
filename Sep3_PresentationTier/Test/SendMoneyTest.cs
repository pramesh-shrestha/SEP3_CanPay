using BlazorServerApp.Pages;
using Bunit;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test {

    public class TransactionTest : IClassFixture<TestContext> {

        private TestContext context;
        private IRenderedComponent<SendMoney> renderedComponent;
        private Mock<ITransactionService> transactionService;

        private void Setup()
        {
            transactionService = new Mock<ITransactionService>();
            var client = new HttpClient();
            var userService = new Mock<IUserService>();
            context = new TestContext();
            context.Services.AddSingleton<ITransactionService>(transactionService.Object);
            context.Services.AddSingleton<IUserService>(userService.Object);
            context.Services.AddSingleton<ICardService>(new CardService(client));
            // renderedComponent = context.RenderComponent<SendMoney>(parameters => parameters.AddSingleton<ITransactionService>(transactionService.Object));
            renderedComponent = context.RenderComponent<SendMoney>();
        }

        private void SetInstancesValue()
        {
            renderedComponent.Instance.sender = "Saran";
            renderedComponent.Instance.receiver = "Kevin";
            renderedComponent.Instance.amount = "100";
        }

        
        [Fact] public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenRecipientNameFieldIsEmpty()
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

        [Fact] public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenAmountFieldIsZero()
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
        

        [Fact] public async Task SendMoneyAsync_ShouldThrowAnErrorMessage_WhenAmountIsNegative()
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