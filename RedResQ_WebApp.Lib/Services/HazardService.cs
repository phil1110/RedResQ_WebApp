using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public class HazardService
    {
        public async static Task<Hazard> Get(long id)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazard/get");

            pathBuilder.AddParameter("id", id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<Hazard>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public async static Task<Hazard[]> Fetch(long? id = null, int? amount = null)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazard/fetch");

            if (id.HasValue)
            {
                pathBuilder.AddParameter("id", id.ToString()!);
            }
            if (amount.HasValue)
            {
                pathBuilder.AddParameter("amount", amount.ToString()!);
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<Hazard[]>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public static async Task<bool> Add(Hazard hazard)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazard/add");

            pathBuilder.AddParameter("title", hazard.Title!);
            pathBuilder.AddParameter("lat", hazard.Latitude.ToString()!);
            pathBuilder.AddParameter("lon", hazard.Longitude.ToString()!);
            pathBuilder.AddParameter("radius", hazard.Radius.ToString()!);
            pathBuilder.AddParameter("typeId", hazard.HazardType!.Id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.PostAsync(pathBuilder.ToString(), null);

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

        public static async Task<bool> Edit(Hazard hazard)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazard/edit");

            pathBuilder.AddParameter("id", hazard.Id.ToString()!);
            pathBuilder.AddParameter("lat", hazard.Latitude.ToString()!);
            pathBuilder.AddParameter("lon", hazard.Longitude.ToString()!);
            pathBuilder.AddParameter("radius", hazard.Radius.ToString()!);
            pathBuilder.AddParameter("typeId", hazard.HazardType!.Id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.PutAsync(pathBuilder.ToString(), null);

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

        public static async Task<bool> Delete(int hazardId)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("hazard/delete");

            pathBuilder.AddParameter("id", hazardId.ToString()!);

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
