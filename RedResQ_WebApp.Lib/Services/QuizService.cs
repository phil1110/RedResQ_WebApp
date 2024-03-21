using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Services
{
    public class QuizService
    {
        public async static Task<Quiz[]> Fetch(long? id = null, int? amount = null, string? query = null, long? quizTypeId = null)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiz/fetch");

            if (id.HasValue)
            {
                pathBuilder.AddParameter("id", id.ToString()!);
            }
            if (amount.HasValue)
            {
                pathBuilder.AddParameter("amount", amount.ToString()!);
            }
            if (query != null)
            {
                pathBuilder.AddParameter("query", query!);
            }
            if (quizTypeId.HasValue)
            {
                pathBuilder.AddParameter("quizTypeId", quizTypeId.ToString()!);
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<Quiz[]>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public static async Task<Quiz> Get(long id)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiz/get");

            pathBuilder.AddParameter("id", id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<Quiz>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }
    }
}
