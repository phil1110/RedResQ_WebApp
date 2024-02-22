using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace RedResQ_WebApp.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        //public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        //{
        //    _sessionStorage = sessionStorage;
        //}

        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    try
        //    {
        //        var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
        //        var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

        //        if (userSession != null)
        //        {
        //            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, userSession.UserName),
        //                new Claim(ClaimTypes.Role, userSession.Role)
        //            }, "CustomAuth"));

        //            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        //        }

        //        return await Task.FromResult(new AuthenticationState(_anonymous));

        //    }
        //    catch
        //    {
        //        return await Task.FromResult(new AuthenticationState(_anonymous));
        //    }
        //}


        private readonly UserAccountService _userAccountService;

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, UserAccountService userAccountService)
        {
            _sessionStorage = sessionStorage;
            _userAccountService = userAccountService;
        }

        // Neuer GetAuthenticationStateAsync
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession != null)
                {
                    var userAccount = await _userAccountService.AuthenticateUser(userSession.UserName, userSession.Password);
                    if (userAccount != null)
                    {
                        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userAccount.UserName),
                            new Claim(ClaimTypes.Role, userAccount.Role)
                        }, "CustomAuth"));

                        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                    }
                }

                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
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
