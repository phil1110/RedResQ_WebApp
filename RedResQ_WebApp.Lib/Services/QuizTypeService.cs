using RedResQ_WebApp.Lib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RedResQ_WebApp.Lib.Services
{
    public class QuizTypeService
    {
        public static async Task<QuizType[]> Fetch(string? name = null)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiztype/fetch");

            if (name != null)
            {
                pathBuilder.AddParameter("name", name!);
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<QuizType[]>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public static async Task<QuizType> Get(long id)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiztype/get");

            pathBuilder.AddParameter("id", id.ToString()!);

            try
            {
                HttpResponseMessage response = await client.GetAsync(pathBuilder.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonService.Deserialize<QuizType>(json)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null!;
        }

        public static async Task<bool> Add(string name)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiztype/add");

            pathBuilder.AddParameter("name", name);

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

        public static async Task<bool> Edit(QuizType quizType)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiztype/edit");


            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(pathBuilder.ToString(), quizType);

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

        public static async Task<bool> Delete(long id)
        {
            var client = Consts.GetHttpClient();
            PathBuilder pathBuilder = new PathBuilder("quiztype/delete");

            pathBuilder.AddParameter("id", id.ToString());

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
