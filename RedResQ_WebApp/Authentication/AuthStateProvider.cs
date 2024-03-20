using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;
using System.Security.Claims;

namespace RedResQ_WebApp.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var jsonResult = await _sessionStorage.GetAsync<string>("UserSession"); 
                var json = jsonResult.Success ? jsonResult.Value : null;

                if (json != null)
                {
                    var claims = JsonService.Deserialize<JwtClaims>(json);

                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Version, claims.Version),
                        new Claim(ClaimTypes.Expiration, claims.Expiration),
                        new Claim(ClaimTypes.NameIdentifier, claims.NameIdentifier),
                        new Claim(ClaimTypes.Name, claims.Name),
                        new Claim(ClaimTypes.Email, claims.Email),
                        new Claim(ClaimTypes.Role, claims.Role),
                        new Claim("exp", claims.Exp)
                    }, "CustomAuth"));

                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }

                return await Task.FromResult(new AuthenticationState(_anonymous));

            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(Claim[] claims)
        {
            ClaimsPrincipal claimsPrincipal;

            if (claims != null)
            {

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

                var jwtClaims = new JwtClaims()
                {
                    Version = claimsPrincipal.FindFirstValue(ClaimTypes.Version),
                    Expiration = claimsPrincipal.FindFirstValue(ClaimTypes.Expiration),
                    NameIdentifier = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier),
                    Name = claimsPrincipal.FindFirstValue(ClaimTypes.Name),
                    Email = claimsPrincipal.FindFirstValue(ClaimTypes.Email),
                    Role = claimsPrincipal.FindFirstValue(ClaimTypes.Role),
                    Exp = claimsPrincipal.FindFirstValue("exp"),
                };

                await _sessionStorage.SetAsync("UserSession", JsonService.Serialize(jwtClaims));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
