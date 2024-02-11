using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public static class LanguageService
    {
        public async static Task<Language[]> Fetch()
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("language/fetch");

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    Language[]? languages = await response.Content.ReadFromJsonAsync<Language[]>();

                    return languages!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }
    }
}
