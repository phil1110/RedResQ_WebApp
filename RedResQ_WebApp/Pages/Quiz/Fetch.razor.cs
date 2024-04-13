using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace RedResQ_WebApp.Pages.Quiz
{
    public partial class Fetch
    {
        private bool firstSearch = true;
        private bool hideAddButton = false;
        private long? Id { get; set; }
        private int? Amount { get; set; }
        private string? Query { get; set; }
        private long? QuizTypeId { get; set; }
        private List<Lib.Models.QuizType> QuizTypes { get; set; } = new List<Lib.Models.QuizType>();
        private List<Lib.Models.Quiz> Quizzes { get; set; } = new List<Lib.Models.Quiz>();

        protected override async Task OnInitializedAsync()
        {
            QuizTypes.AddRange(await QuizTypeService.Fetch());
        }

        private async Task Search()
        {
            Quizzes.Clear();

            Quizzes.AddRange(await LoadQuizzes());

            hideAddButton = false;
        }

        private async Task LoadMoreQuizzes()
        {
            var tempId = Id;
            Id = Quizzes[Quizzes.Count - 1].Id + 1;

            var quizzes = await LoadQuizzes();

            Id = tempId;

            if (quizzes != null)
            {
                Quizzes.AddRange(quizzes);
            }
            else
            {
                hideAddButton = true;
            }
        }

        private async Task<Lib.Models.Quiz[]> LoadQuizzes()
        {
            long? tempId = Id;

            if (firstSearch)
            {
                firstSearch = false;
            }
            if (tempId.HasValue)
            {
                tempId--;
            }

            return await QuizService.Fetch(tempId, Amount, Query, QuizTypeId);
        }
    }
}
