using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Lib.Services
{
	public static class UserService
	{
		public async static Task<User[]> Fetch(long? id, int? amount)
		{
			HttpClient client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("user/fetch");

			if (id.HasValue)
			{
                pathBuilder.AddParameter("id", $"{id.Value}");
			}

            if (amount.HasValue)
            {
                pathBuilder.AddParameter("amount", $"{amount.Value}");
			}

			HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
			if (response.IsSuccessStatusCode)
			{
				User[]? users = await response.Content.ReadFromJsonAsync<User[]>();

				return users!;
			}

			return null!;
		}

        public async static Task<User[]?> Search(string username)
        {
            HttpClient client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("user/search");

            pathBuilder.AddParameter("query", username);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
                Console.WriteLine(response);

                // API liefert anscheinend nicht einen User sondern meherere
                // Ich muss aber einen User erhalten

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);


                    User[]? users = await response.Content.ReadFromJsonAsync<User[]>();
                    if (users != null)
                    {
                        return users;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Invalid JSON response for user.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error searching user. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error searching user. Message: {ex.Message}");
            }

            return null;
        }


        public async static Task Delete(long id)
		{
			HttpClient client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("user/delete");

            pathBuilder.AddParameter("id", $"{id}");

            try
            {
                await client.DeleteAsync(pathBuilder.ToString());
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting user. Message: {ex.Message}");
            }

        }
    }
}
