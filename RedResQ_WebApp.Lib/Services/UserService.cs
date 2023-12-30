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

			string path = "user/fetch";

			if (id.HasValue)
			{
				path += "?id=" + id.Value;
			}
			if (amount.HasValue)
			{
				if (path.Contains('?'))
				{
					path += "&amount=" + amount.Value;
				}
				else
				{
					path += "?amount=" + amount.Value;
				}
			}

			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				User[]? users = await response.Content.ReadFromJsonAsync<User[]>();

				return users!;
			}

			return null!;
		}

        public async static Task<User?> Search(string username)
        {
            HttpClient client = Consts.GetHttpClient();

            string path = $"user/search?query={username}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    User? user = await response.Content.ReadFromJsonAsync<User>();
                    return user;
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

			string path = $"user/delete/?id={id}";

            try
            {
                await client.DeleteAsync(path);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting user. Message: {ex.Message}");
            }

        }
    }
}
