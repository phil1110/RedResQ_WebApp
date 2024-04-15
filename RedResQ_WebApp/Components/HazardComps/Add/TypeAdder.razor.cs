using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.HazardComps.Add
{
    public partial class TypeAdder
    {
        private string? TypeName { get; set; }

        [Parameter]
        public Action AfterAction { get; set; }

        [Parameter]
        public Action TogglerAction { get; set; }

        private async Task AddType()
        {
            await HazardTypeService.Add(TypeName!);
            AfterAction();
        }
    }
}
