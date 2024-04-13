using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.QuizTypeComps.Fetch
{
    public partial class DeleteButton
    {
        private bool _showPopUp = false;

        [Parameter]
        public QuizType? QuizType { get; set; }

        public void TogglePopUp()
        {
            _showPopUp = !_showPopUp;
        }

        public async void DeleteQuizType()
        {
            bool deletedSuccessfully = await QuizTypeService.Delete(QuizType!.Id!.Value);

            if (deletedSuccessfully)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
    }
}
