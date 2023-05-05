using BlazorServerApp.Pages;
using Bunit;
using HTTPClients.ClientInterfaces;
using HTTPClients.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Test; 

public class LoginTest : IClassFixture<TestContext> {

    private TestContext context;
    private IRenderedComponent<Login> renderedComponent;

    private void Setup() {
        context = new TestContext();
        context.Services.AddSingleton<IUserService>(new UserService(new HttpClient()));
        renderedComponent = context.RenderComponent<Login>();
    }

    private void SetInstancesValue() {
        
    }

    [Fact]
    public void ErrorMessageWhenUsernameIsEmpty() {
        
    }
}