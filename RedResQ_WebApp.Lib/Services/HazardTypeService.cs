using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public class HazardTypeService
    {
        public async static Task<HazardType[]> Fetch()
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazardtype/fetch");

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<HazardType[]>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public static async Task<bool> Add(string hazardTypeName)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazardtype/add");

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<string>(pathBuilder.ToString(), hazardTypeName);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static async Task<bool> Edit(HazardType hazardType)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazardtype/edit");

            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync<HazardType>(pathBuilder.ToString(), hazardType);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static async Task<bool> Delete(int hazardTypeId)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazardtype/delete");

            pathBuilder.AddParameter("id", hazardTypeId.ToString()!);

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
