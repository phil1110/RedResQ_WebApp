using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;

namespace RedResQ_WebApp.Components.StatComps.StatTypes
{
    public partial class PieChart
    {
        private PieConfig? _pieConfig;

        [Parameter]
        public Dictionary<string, int>? Data { get; set; }

        [Parameter]
        public string? Title { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(ChartInit);
        }

        private void ChartInit()
        {
            List<string> colors = new List<string>();
            _pieConfig = new PieConfig();

            _pieConfig.Options = new PieOptions()
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = Title
                }
            };

            foreach (var label in Data!.Keys.ToArray())
            {
                _pieConfig.Data.Labels.Add(label);
            }

            foreach (var value in Data!.Values.ToArray())
            {
                colors.Add(ColorUtil.RandomColorString());
            }

            var dataset = new PieDataset<int>(Data!.Values.ToArray())
            {
                BackgroundColor = colors.ToArray()
            };

            _pieConfig.Data.Datasets.Add(dataset);
        }
    }
}
