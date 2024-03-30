using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Lib.Services
{
	public class UserService
	{
		public async Task<User[]> Fetch(long? id, int? amount)
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

        public async Task<User[]?> Search(string username)
        {
            HttpClient client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("user/search");

            pathBuilder.AddParameter("query", username);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
                Console.WriteLine(response);

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


        public async Task Delete(long id)
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

        public async Task<User?> GetUserById(long id)
        {
            HttpClient client = Consts.GetHttpClient();
            string requestUrl = $"user/get?id={id}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    User? user = await response.Content.ReadFromJsonAsync<User>();
                    return user;
                }
                else
                {
                    Console.WriteLine($"Error getting user by ID. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting user by ID. Message: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> UpdateUser(User user)
        {
            HttpClient client = Consts.GetHttpClient();
            string requestUrl = $"user/update";

            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(requestUrl, user);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User successfully updated.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating user. Status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating user. Message: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            HttpClient client = Consts.GetHttpClient();
            string requestUrl = "https://api.redresq.at/role/fetch";

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    List<Role>? roles = await response.Content.ReadFromJsonAsync<List<Role>>();
                    return roles ?? new List<Role>(); 
                }
                else
                {
                    Console.WriteLine($"Error getting roles. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting roles. Message: {ex.Message}");
            }

            return new List<Role>(); 
        }


        public async Task<bool> PromoteUser(long userId, long roleId)
        {
            HttpClient client = Consts.GetHttpClient();
            string requestUrl = "https://api.redresq.at/user/promote"; 

            var requestData = new { userId, roleId }; 

            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(requestUrl, requestData);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User role successfully updated.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error promoting user. Status code: {response.StatusCode}");
                    Console.WriteLine($"Else Zweig");

                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error promoting user. Message: {ex.Message}");
                return false;
            }
        }
    }
}
