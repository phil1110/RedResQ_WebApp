using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public static class CountryService
    {
        public async static Task<Country[]> Fetch()
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("country/fetch");

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    Country[]? countries = await response.Content.ReadFromJsonAsync<Country[]>();

                    return countries!;
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
