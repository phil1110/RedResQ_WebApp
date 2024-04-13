using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.QuizTypeComps.Fetch
{
    public partial class AddButton
    {
        private bool _showPopUp = false;

        private string? Name {  get; set; }

        public void TogglePopUp()
        {
            _showPopUp = !_showPopUp;
        }

        public async Task SubmitQuizType()
        {
            bool wasSuccessful = await QuizTypeService.Add(Name!);

            if (wasSuccessful)
            {
                NavigationManager.NavigateTo(NavigationManager.Uri, true);
            }
        }
    }
}
