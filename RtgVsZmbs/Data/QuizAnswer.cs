using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    public class QuizAnswer
    {
        public Int64 ID { get; private set; }

        public int TypeID { get; private set; }

        public string Answer { get; set; }

        public Boolean IsCorrect { get; set; }

        public QuizAnswer(Int64 id, string answer, Boolean isCorrect, int typeid)
        {
            ID = id;
            Answer = answer;
            IsCorrect = isCorrect;
            TypeID = typeid;
        }

    }
}
