using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.QuizComps.Show
{
    public partial class QuizView
    {
        private Quiz? _quiz;

        [Parameter]
        public long QuizId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _quiz = await QuizService.Get(QuizId);
            StateHasChanged();
        }
    }
}
