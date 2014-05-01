using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    class Quizcard
    {
        private long id;
        private String question;
        private QuizAnswer[] answers;

        private Quizcard(long id, String question, QuizAnswer[] answers)
        {
            this.id = id;
            this.question = question;
            this.answers = answers;
        }

        public long getId
        {
            get
            {
                return id;
            }
        }

        public String getQuestion
        {
            get
            {
                return question;
            }
        }

        public QuizAnswer[] getAnswers
        {
            get
            {
                return answers;
            }
        }

        public long answerCount
        {
            get
            {
                if (answers != null)
                {
                    return answers.LongLength;
                }
                return 0;
            }
        }
    }
}
