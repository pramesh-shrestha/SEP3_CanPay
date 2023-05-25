// class responsible for providing the Blazor app auth functionality with the authorization state (i.e. who is logged in,
// if any)


using System.Security.Claims;
using HTTPClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServerApp.Auth;

/// <summary>
/// Provides authentication functionality for the Blazor app, managing the authorization state.
/// </summary>
public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IUserService userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomAuthProvider"/> class.
    /// </summary>
    /// <param name="userService">The user service used for authentication.</param>
    public CustomAuthProvider(IUserService userService)
    {
        this.userService = userService;
        userService.OnAuthStateChanged += AuthStateChanged;
    }

    /// <summary>
    /// Handles the authentication state change event and notifies the authentication state change.
    /// </summary>
    /// <param name="principal">The new claims principal representing the authentication state.</param>
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    /// <summary>
    /// Retrieves the current authentication state asynchronously.
    /// </summary>
    /// <returns>The current authentication state.</returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await userService.GetAuthAsync();
        return new AuthenticationState(principal);
    }
}