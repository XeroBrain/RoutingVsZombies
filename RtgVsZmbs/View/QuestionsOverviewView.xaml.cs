using System.Collections.Generic;
using System.Windows;
using RtgVsZmbs.Data;
using RtgVsZmbs.Objects;

namespace RtgVsZmbs.View
{
    /// <summary>
    /// Interaction logic for QuestionsOverviewView.xaml
    /// </summary>
    public partial class QuestionsOverviewView : Window
    {
        public QuestionsOverviewView()
        {
            InitializeComponent();
            loadQuizcards();
        }

        public List<Quizcard> QuestionList
        {
            get { return _questionList; }
        }

        private List<Quizcard> _questionList;

        public void loadQuizcards()
        {
            _questionList = new List<Quizcard>();
            SQLFactory.InitConnection();
            var questions = SQLFactory.GetAllQuestions();
            foreach (Quizcard question in questions)
            {
                _questionList.Add(question);
            }
        }
    }
}
