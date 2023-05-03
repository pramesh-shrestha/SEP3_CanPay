// class responsible for providing the Blazor app auth functionality with the authorization state (i.e. who is logged in,
// if any)


using System.Security.Claims;
using HTTPClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServerApp.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private IUserService userService;

    public CustomAuthProvider(IUserService userService)
    {
        this.userService = userService;
        userService.OnAuthStateChanged += AuthStateChanged;

    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await userService.GetAuthAsync();

        return new AuthenticationState(principal);
    }
}