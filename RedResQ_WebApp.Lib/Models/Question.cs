using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Question
    {
        public long QuizId { get; set; }

        public long Id { get; set; }

        public string? Text { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
