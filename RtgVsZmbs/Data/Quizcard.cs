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

        private int _achievedPoints;

        public int AchievedPoints {
            get
            {
                return _achievedPoints;
            }
            set
            {
                if (value > 0)
                {
                    AlreadyAnswered = true;
                }
                this._achievedPoints = value;
                ;
            } }

        public bool AlreadyAnswered { get; private set; }

        private Quizcard(int id, string question, List<QuizAnswer> answers, int maxPoints)
        {
            this.Id = id;
            this.Question = question;
            this.Answers = answers;
            this.MaximumPoints = maxPoints;
            this._achievedPoints = 0;
            this.AlreadyAnswered = false;
        }

        public int Id { get; private set; }

        public string Question { get; private set; }

        public List<QuizAnswer> Answers { get; private set; }

        public int AnswerCount
        {
            get
            {
                if (Answers != null)
                {
                    return Answers.Count();
                }
                return 0;
            }
        }
    }
}
