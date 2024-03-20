using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib
{
    public static class Consts
    {
        private const string BASE_ADDRESS = "https://api.redresq.at";

        public static string? AuthToken { get; set; }

        public static bool IsAuthorized { get; private set; }

        public static void Authorize(string token)
        {
            IsAuthorized = true;
            AuthToken = token;
        }

        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(BASE_ADDRESS);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", AuthToken);

            return client;
        }
    }
}
