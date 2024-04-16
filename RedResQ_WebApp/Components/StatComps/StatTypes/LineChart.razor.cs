using ChartJs.Blazor.Common;
using ChartJs.Blazor.LineChart;
using Microsoft.AspNetCore.Components;

namespace RedResQ_WebApp.Components.StatComps.StatTypes
{
    public partial class LineChart
    {
        private LineConfig? _lineConfig;

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
            _lineConfig = new LineConfig();
            string color = "rgb(11, 102, 230, 0.25)";

            _lineConfig.Options = new LineOptions()
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
                _lineConfig.Data.Labels.Add(label);
            }

            var dataset = new LineDataset<int>(Data!.Values.ToArray())
            {
                Label = Title,
                BackgroundColor = color
            };

            _lineConfig.Data.Datasets.Add(dataset);
        }
    }
}
