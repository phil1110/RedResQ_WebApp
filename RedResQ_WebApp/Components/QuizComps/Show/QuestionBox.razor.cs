using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Components.QuizComps.Show
{
    public partial class QuestionBox
    {
        [Parameter]
        public Question? Question { get; set; }
    }
}
