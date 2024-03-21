using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Answer
    {
        public long QuizId { get; set; }

        public long QuestionId { get; set; }

        public long Id { get; set; }

        public string? Text { get; set; }

        public bool IsTrue { get; set; }
    }
}
