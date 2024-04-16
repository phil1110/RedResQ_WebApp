using Microsoft.AspNetCore.Components;
using RedResQ_WebApp.Components.StatComps.StatTypes;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.StatComps
{
	public partial class Stat
	{
		private int? _chartType;
		private string? _chartName;
		private Dictionary<string, int>? _data;

		private bool _showOverlay = false;

		[Parameter]
		public string StatType { get; set; }

		protected override async Task OnInitializedAsync()
		{
			_chartType = Convert.ToInt32(StatType.Split('_')[1]);
            var tempChartName = StatType.Split('_')[2];

			foreach (char c in tempChartName)
			{
				if (char.IsUpper(c))
				{
					if(_chartName?.Length > 0)
					{
						_chartName += " " + c;
					}
					else
					{
						_chartName += c;
					}
                }
                else
                {
                    _chartName += c;
                }
            }

            _data = await StatService.GetStatByType(StatType);
		}

		private void ToggleOverlay()
		{
			_showOverlay = !_showOverlay;
		}
	}
}
