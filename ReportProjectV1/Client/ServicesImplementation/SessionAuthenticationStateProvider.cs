using Microsoft.AspNetCore.Components.Authorization;

namespace ReportProjectV1.Client.ServicesImplementation
{
    public class SessionAuthenticationStateProvider : AuthenticationStateProvider
    {
    
public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
            /*  var sessionID = await jsRuntime.InvokeAsync<string>("eval", "document.cookie.split('; ').find(row => row.startsWith('sessionID=')).split('=')[1]");
              if (!string.IsNullOrEmpty(sessionID))
              {
                  var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "user") }, "session");
                  var principal = new ClaimsPrincipal(identity);
                  return new AuthenticationState(principal);
              }
              else
              {
                  return new AuthenticationState(new ClaimsPrincipal());
            } */
        }
    }
}
