using Microsoft.AspNetCore.Components.Authorization;

namespace RedResQ_WebApp.Lib
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

