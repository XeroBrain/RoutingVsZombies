using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace RtgVsZmbs.Objects
{
    class ADOFactory
    {
        private String mdbFilepath = "\\DB\\RvsZ_MDB.mdb";
        private String adoProvider = "Microsoft.Jet.OLEDB.4.0";
        private String userid = "admin";
        private String password = "";

        private ADOFactory()
        {
            // this is an utility class and must not be extended
        }

        public static Quizcard[] GetAllQuizcards()
        {
            return null;
        }

        public Quizcard GetQuizcard(long id)
        {
            return null;
        }

        public static bool SaveQuizcard(Quizcard qc)
        {
            return false;
        }
    }
}
