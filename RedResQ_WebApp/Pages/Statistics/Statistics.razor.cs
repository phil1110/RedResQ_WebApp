using RedResQ_WebApp.Components.StatComps;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Pages.Statistics
{
	public partial class Statistics
	{
		private string[]? _statTypes;
		private string[]? _statChapters;

		protected override async Task OnInitializedAsync()
		{
			var chapterList = new List<string>();

			_statTypes = await StatService.GetStatTypes();

			foreach (var statType in _statTypes)
			{
				chapterList.Add(statType.Split('_')[0]);
			}

			_statChapters = chapterList.Distinct().ToArray();
		}
	}
}
