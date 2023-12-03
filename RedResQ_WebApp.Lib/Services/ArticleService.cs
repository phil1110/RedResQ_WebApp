using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public static class ArticleService
    {
        public static async Task<Article[]> GetArticles(long? id = null)
        {
            HttpClient client = Consts.GetHttpClient();

            if(id != null)
            {
                HttpResponseMessage response = await client.GetAsync($"news/fetch?articleId={id.Value}");
                if (response.IsSuccessStatusCode)
                {
                    Article[]? articles = await response.Content.ReadFromJsonAsync<Article[]>();

                    return articles!;
                }
            }
            else
            {
                HttpResponseMessage response = await client.GetAsync($"news/fetch");
                if (response.IsSuccessStatusCode)
                {
                    Article[]? articles = await response.Content.ReadFromJsonAsync<Article[]>();

                    return articles!;
                }
            }

            return null!;
        }
    }
}
