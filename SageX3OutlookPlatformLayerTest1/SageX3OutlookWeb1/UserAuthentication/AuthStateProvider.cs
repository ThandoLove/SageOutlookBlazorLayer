using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SageX3OutlookWeb1.UserAuthentication;

public class AuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _user = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => Task.FromResult(new AuthenticationState(_user));

    public void MarkUserAsAuthenticated(string email, string role)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role)
        }, "apiauth");
        _user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
    }

    public void MarkUserAsLoggedOut()
    {
        _user = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_user)));
    }
}