using RedResQ_WebApp.Lib.Models;
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
		public static async Task<Article[]> FetchArticles(long? articleId, long? countryId, long? languageId)
		{
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("news/fetch");

			if (articleId.HasValue)
			{
				pathBuilder.AddParameter("articleId", articleId.ToString()!);
			}
			if(countryId.HasValue)
			{
                pathBuilder.AddParameter("countryId", countryId.ToString()!);
            }
            if (languageId.HasValue)
            {
                pathBuilder.AddParameter("languageId", languageId.ToString()!);
            }

			try
			{
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    Article[]? articles = await response.Content.ReadFromJsonAsync<Article[]>();

                    return articles!;
                }
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
            }

            return null!;
        }

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
