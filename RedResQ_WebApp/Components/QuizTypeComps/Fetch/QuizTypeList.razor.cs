using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;
using System.ComponentModel;

namespace RedResQ_WebApp.Components.QuizTypeComps.Fetch
{
    public partial class QuizTypeList
    {
        private List<QuizType> QuizTypes { get; set; } = new List<QuizType>();

        protected async override Task OnInitializedAsync()
        {
            QuizTypes.AddRange(await QuizTypeService.Fetch());
        }
    }
}
