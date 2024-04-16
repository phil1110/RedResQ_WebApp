using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;

namespace RedResQ_WebApp.Components.StatComps.StatTypes
{
    public partial class BarChart
    {
        private BarConfig? _barConfig;

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
            _barConfig = new BarConfig();

            _barConfig.Options = new BarOptions()
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
                _barConfig.Data.Labels.Add(label);
            }

            foreach (var value in Data!.Values.ToArray())
            {
                string color = ColorUtil.RandomColorString();

                colors.Add(color.Split(',')[0] + "," + color.Split(',')[1] + "," + color.Split(',')[2] + ", 0.5)");
            }

            var dataset = new BarDataset<int>(Data!.Values.ToArray())
            {
                BackgroundColor = colors.ToArray(),
                Label = Title
            };

            _barConfig.Data.Datasets.Add(dataset);
        }
    }
}
