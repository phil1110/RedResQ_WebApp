using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Components.QuizComps.Add
{
    public partial class AnswerView
    {
        public Answer Answer { get; set; }

        public AnswerView()
        {
            Answer = new Answer();
        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public Answer GetAnswer(int questionId, int id)
        {
            var answer = Answer;

            answer.QuestionId = questionId;
            answer.Id = id;

            return answer;
        }
    }
}
