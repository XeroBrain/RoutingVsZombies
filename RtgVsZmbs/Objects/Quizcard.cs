using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    class Quizcard
    {
        public int MaximumPoints { get; private set; }

        private int AchievedPoints { get; set; }

        private Quizcard(int id, string question, QuizAnswer[] answers, int maxPoints)
        {
            this.Id = id;
            this.Question = question;
            this.Answers = answers;
            this.MaximumPoints = maxPoints;
        }

        public int Id { get; private set; }

        public string Question { get; private set; }

        public QuizAnswer[] Answers { get; private set; }

        public long AnswerCount
        {
            get
            {
                if (Answers != null)
                {
                    return Answers.LongLength;
                }
                return 0;
            }
        }
    }
}
