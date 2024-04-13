using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Components.QuizComps.Fetch
{
    public partial class ShowButton
    {
        private bool _showPopUp = false;

        [Parameter]
        public Quiz? Quiz { get; set; }

        public void TogglePopUp()
        {
            _showPopUp = !_showPopUp;
        }
    }
}
