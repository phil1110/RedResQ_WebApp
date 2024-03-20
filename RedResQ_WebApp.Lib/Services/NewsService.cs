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

		public static async Task<Article> Get(long id)
		{
			var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("news/get");

            pathBuilder.AddParameter("id", id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    Article? article = await response.Content.ReadFromJsonAsync<Article>();

                    return article!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

		public static async Task Update(Article article)
		{
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("news/update");

            try
            {
				HttpResponseMessage response = await client.PutAsJsonAsync<Article>(pathBuilder.ToString(), article);

                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadFromJsonAsync<object>();

                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

			return;
        }

		public async static Task CreateNews(string title, string content, string author, DateTime date, long? language, long image, long? country)
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
				Country = country
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

        public async static Task Delete(long id)
        {
            HttpClient client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("news/delete");

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

        public async static Task<Article?> GetArticleById(long id)
        {
            HttpClient client = Consts.GetHttpClient();
            string requestUrl = $"news/get?id={id}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    Article? article = await response.Content.ReadFromJsonAsync<Article>();
                    return article;
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
    }
}
