using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
	public class NewsService
	{
		public async static Task CreateNews(string title, string content, string author, DateTime date, int language, int image, int location)
		{
			HttpClient client = Consts.GetHttpClient();

			//string path = $"news/add?title={title}&content={content}&author={author}&date={date}&language={language}&image={image}&location={location}";

			string path = $"news/add/";

			var newsData = new
			{
				Title = title,
				Content = content,
				Author = author,
				Date = date,
				Language = language,
				Image = image,
				Location = location
			};

			try
			{
				HttpResponseMessage response = await client.PostAsJsonAsync(path, newsData);

				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine("News created successfully!");
				}
				else
				{
					Console.WriteLine($"Error creating news. Status code: {response.StatusCode}");
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error creating news. Message: {ex.Message}");
			}

		}
	}
}
