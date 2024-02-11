using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Article
    {
        #region Constructor

        public Article(long id, string title, string content, string author, DateTime date, Language language,
            Country country, Image? image = null)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
            Date = date;
            Language = language;
            Image = image;
            Country = country;
        }

        #endregion

        #region Properties

        [JsonRequired]
        public long Id { get; set; }

        [JsonRequired]
        public string Title { get; set; }

        [JsonRequired]
        public string Content { get; set; }

        [JsonRequired]
        public string Author { get; set; }

        [JsonRequired]
        public DateTime Date { get; set; }

        [JsonRequired]
        public Language Language { get; set; }

        public Image? Image { get; set; }

        [JsonRequired]
        public Country Country { get; set; }

        #endregion
    }
}
