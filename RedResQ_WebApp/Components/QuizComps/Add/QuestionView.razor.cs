using Microsoft.JSInterop;
using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Components.QuizComps.Add
{
    public partial class QuestionView
    {
        public Question Question { get; set; }
        private List<AnswerView> AnswerViews;

        private AnswerView AnswerViewRef
        {
            set
            {
                AnswerViews.Add(value);
            }
        }

        public QuestionView()
        {
            Question = new Question();
            AnswerViews = new List<AnswerView>();
        }

        public void Refresh()
        {
            StateHasChanged();
        }

        public void AddAnswer()
        {
            Question.Answers.Add(new Answer());
        }

        public void ClearAnswers()
        {
            Question.Answers.Clear();
        }

        public Question GetQuestion(int questionId)
        {
            var question = new Question();

            question.Id = questionId;
            question.Text = Question.Text;

            for (int i = 0; i < AnswerViews.Count; i++)
            {
                question.Answers.Add(AnswerViews[i].GetAnswer(questionId, i + 1));
            }

            return question;
        }
    }
}
