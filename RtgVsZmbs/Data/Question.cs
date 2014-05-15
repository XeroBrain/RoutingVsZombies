using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RtgVsZmbs.Objects;

namespace RtgVsZmbs.Data
{
    class Question
    {
        private int _level;

        public Question(Int64 id, String question, int level, QuizAnswer[] answers)
        {
            this.GetId = id;
            this.GetQuestion = question;
            this._level = level;
            this.GetAnswers = answers;
        }

        public Int64 GetId { get; private set; }

        public string GetQuestion { get; private set; }

        public QuizAnswer[] GetAnswers { get; private set; }

        public Int64 AnswerCount
        {
            get
            {
                if (GetAnswers != null)
                {
                    return GetAnswers.LongLength;
                }
                return 0;
            }
        }
    }
}
