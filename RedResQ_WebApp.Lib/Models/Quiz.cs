using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Quiz
    {
        public long? Id { get; set; }

        public string? Name { get; set; }    

        public int? MaxScore { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();

        public QuizType? Type { get; set; }
    }
}
