using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    class SQLFactory
    {
        private SQLFactory()
        {
            // this is an utility class and must not be extended
        }

        public static Quizcard[] getAllQuizcards()
        {
            return null;
        }

        public static Quizcard getQuizcard(long id)
        {
            return null;
        }

        public static bool saveQuizcard(Quizcard qc)
        {
            return false;
        }
    }
}
