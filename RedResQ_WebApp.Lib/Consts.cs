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
        public const string BASE_ADDRESS = "https://api.redresq.at";

        public static string? AuthToken { get; private set; } = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJwaGlscmVjayIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InBoaWxpcHByZWNrbmFnZWxAb3V0bG9vay5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiI2IiwiZXhwIjoxNzA2OTgyNTUyfQ.RqBu8X5sGBnY_vW_JFrlA5Hi0tAiCZz4C_SQrRYhiML8E-KPHo2UgoAz_UDnCAAmzNrZRSMC3QgejaofhJeDKw";

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
