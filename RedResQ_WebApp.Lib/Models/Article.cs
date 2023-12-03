﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RedResQ_WebApp.Lib.Models
{
    public class Article
    {
        #region Constructor

        public Article(long id, string title, string content, string author, DateTime date, Language language,
            Image image, Location location)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
            Date = date;
            Language = language;
            Image = image;
            Location = location;
        }

        #endregion

        #region Properties

        public long Id { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Author { get; private set; }

        public DateTime Date { get; private set; }

        public Language Language { get; private set; }

        public Image Image { get; private set; }

        public Location Location { get; private set; }

        #endregion
    }
}
