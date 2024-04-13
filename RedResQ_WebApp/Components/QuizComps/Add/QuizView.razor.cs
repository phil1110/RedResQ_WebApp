using Microsoft.AspNetCore.Http.Extensions;
using RedResQ_WebApp.Lib.Models;
using RedResQ_WebApp.Lib.Services;

namespace RedResQ_WebApp.Components.QuizComps.Add
{
    public partial class QuizView
    {
        public Quiz? Quiz { get; set; }
        private List<QuestionView> QuestionViews;

        public QuestionView QuestionViewRef
        {
            set
            {
                QuestionViews.Add(value);
            }
        }

        public QuizView()
        {
            QuestionViews = new List<QuestionView>();
        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void AddQuestion()
        {
            Quiz!.Questions.Add(new Question());
        }

        public void ClearQuestions()
        {
            Quiz!.Questions.Clear();
        }

        public async Task PublishQuiz()
        {
            var quiz = Quiz!;

            quiz.Id = 0;

            quiz.Questions.Clear();

            for (int i = 0; i < QuestionViews.Count; i++)
            {
                quiz.Questions.Add(QuestionViews[i].GetQuestion(i + 1));
            }

            bool wasSuccessful = await QuizService.Add(quiz);

            if (wasSuccessful)
            {
                NavigationManager.NavigateTo("/quiz");
            }
        }
    }
}
