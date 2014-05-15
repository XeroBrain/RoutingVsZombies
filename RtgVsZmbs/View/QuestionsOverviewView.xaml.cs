using System.Collections.Generic;
using System.Windows;
using RtgVsZmbs.Data;

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
        }

        public List<Quizcard> QuestionList
        {
            get { return _questionList; }
        }

        private List<Quizcard> _questionList;
    }
}
