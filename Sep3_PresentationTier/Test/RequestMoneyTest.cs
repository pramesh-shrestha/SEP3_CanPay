using BlazorServerApp.Pages;
using Bunit;
using Entity.Model;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Test;

public class RequestMoneyTest : IClassFixture<TestContext>
{
    private TestContext context;
    private IRenderedComponent<SendMoney> renderedComponent;
    private Mock<IRequestService> requestService;

    private void Setup()
    {
        requestService = new Mock<IRequestService>();
        HttpClient client = new HttpClient();
        var userService = new Mock<IUserService>();
        context = new TestContext();


        context.Services.AddSingleton<IRequestService>(new RequestService(client));
        context.Services.AddSingleton<IUserService>(new UserService(client));
        context.Services.AddSingleton<ITransactionService>(new TransactionService(client));
        context.Services.AddSingleton<INotificationService>(new NotificationService(client));
        context.Services.AddAuthorization();
        renderedComponent = context.RenderComponent<SendMoney>();
    }

    private void SetInstanceValue()
    {
        renderedComponent.Instance.sender = "Suhani";
        renderedComponent.Instance.receiver = "test";
        renderedComponent.Instance.amount = "500";
    }

    [Fact]
    public async Task ErrorMessage_WhenReceiverIsNotSelected()
    {
        Setup();
        SetInstanceValue();
        renderedComponent.Instance.receiver = "";
        await renderedComponent.Instance.GetErrorMessage();
        Assert.Equal("Receiver must be selected.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task ErrorMessage_WhenAmountIsLessThanZero()
    {
        Setup();
        SetInstanceValue();
        renderedComponent.Instance.amount = "0";
        await renderedComponent.Instance.GetErrorMessage();
        Assert.Equal("Amount must be more than 0.", renderedComponent.Instance.errorLabel);
    }

    [Fact]
    public async Task ErrorMessage_WhenAmountIsNegativeNumber()
    {
        Setup();
        SetInstanceValue();
        renderedComponent.Instance.amount = "-20";
        await renderedComponent.Instance.GetErrorMessage();
        Assert.Equal("Amount must be more than 0.", renderedComponent.Instance.errorLabel);
    }
    
}