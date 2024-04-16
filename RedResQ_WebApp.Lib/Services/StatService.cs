using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Lib.Services
{
	public class StatService
	{
		public static async Task<string[]> GetStatTypes()
		{
			var client = Consts.GetHttpClient();
			PathBuilder pathBuilder = new PathBuilder("stattype");

			try
			{
				HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadFromJsonAsync<string[]>();
				}
				else
				{
					Console.WriteLine($"Error getting quiz types. Status code: {response.StatusCode}");
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error getting quiz types. Message: {ex.Message}");
			}

			return null!;
		}

		public static async Task<Dictionary<string, int>> GetStatByType(string statType)
		{
			var client = Consts.GetHttpClient();
			PathBuilder pathBuilder = new PathBuilder("stat");

			pathBuilder.AddParameter("statName", statType);

			try
			{
				HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());
				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadFromJsonAsync<Dictionary<string, int>>();
				}
				else
				{
					Console.WriteLine($"Error getting quiz by type '{statType}'. Status code: {response.StatusCode}");
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error getting quiz by type '{statType}'. Message: {ex.Message}");
			}

			return null!;
		}
	}
}
