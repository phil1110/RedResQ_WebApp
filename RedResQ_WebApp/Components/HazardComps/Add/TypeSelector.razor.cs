using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;
using System.Runtime.CompilerServices;

namespace RedResQ_WebApp.Components.HazardComps.Add
{
    public partial class TypeSelector
    {
        private bool _showAdder = false;
        private HazardType[]? _hazardTypes;
        private int? _hazardId;

        protected override async Task OnInitializedAsync()
        {
            await LoadTypes();
        }

        private async Task LoadTypes()
        {
            _hazardTypes = await HazardTypeService.Fetch();
            _showAdder = false;

            StateHasChanged();
        }

        private void ToggleAdder()
        {
            _showAdder = !_showAdder;
        }
    }
}
