using System;
using System.Runtime.CompilerServices;

namespace RedResQ_WebApp.Lib.Services
{
    public class AuthService
    {
        public static async Task<string> Login(string identifier, string pwd)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("auth/login");
            
            pathBuilder.AddParameter("id", identifier);
            pathBuilder.AddParameter("secret", pwd);
            
            HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
            
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                Consts.AuthToken = token;

                return token;
            }

            return null!;
        }

        public static async Task<string> RequestGuestToken()
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("guest/request");

            HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                Consts.AuthToken = token;

                return token;
            }

            return null!;
        }
    }
}

