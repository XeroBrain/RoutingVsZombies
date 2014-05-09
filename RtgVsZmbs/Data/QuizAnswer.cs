using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    class QuizAnswer
    {
        public int ID { get; private set; }

        public string Answer { get; set; }

        QuizAnswer(int id, string answer)
        {
            ID = id;

            Answer = answer;
        }

    }
}
