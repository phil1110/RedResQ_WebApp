using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.QuizComps.Fetch
{
    public partial class DeleteButton
    {
        [Parameter]
        public Quiz? Quiz { get; set; }


        public async void DeleteQuiz()
        {
            bool deletedSuccessfully = await QuizService.Delete(Quiz!.Id!.Value);

            if (deletedSuccessfully)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
    }
}
