using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RtgVsZmbs.Data;

namespace RtgVsZmbs.Objects
{
    internal class SQLFactory
    {
        private const String Serveraddress = "85.183.21.62";
        private const String Userid = "RVZLogin";
        private const String Password = "ZombieNation21!";
        private static String dbname = "RoutingVsZombie";
        private const String AppName = "RoutingVsZombies_Client";
        private static SqlConnection _sqlcon = null;

        private SQLFactory()
        {
            // this is an utility class and must not be extended
        }

        public static void InitConnection()
        {
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = Serveraddress;
            conBuilder.UserID = Userid;
            conBuilder.Password = Password;
            conBuilder.ApplicationName = AppName;
            conBuilder.ApplicationIntent = ApplicationIntent.ReadWrite;
            _sqlcon = new SqlConnection(conBuilder.ConnectionString);
            _sqlcon.Open();
        }

        public static void CloseConnection()
        {
            _sqlcon.Close();
            _sqlcon = null;
        }

        public static Question[] GetAllQuestions()
        {
            const string sqlStatement = "SELECT queid FROM Questions;";
            var questions = new List<Question>();
            SqlCommand sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            var ids = new List<Int64>();
            while (sqldata.Read())
            {
                ids.Add(sqldata.GetInt64(1));
            }
            sqldata.Close();
            foreach (Int64 id in ids)
            {
                questions.Add(GetQuestion(id));
            }
            return questions.ToArray();
        }

        public static Question GetQuestion(Int64 id)
        {
            String sqlStatement =
                "SELECT queid, queLevel, queQuestion, igsType, igsImage, awsid, awsAnswer, awsTypeid, awsIsCorrect " +
                "FROM Questions LEFT JOIN Images ON queigsid=igsid, Answers " +
                "WHERE queid = " + id + " " +
                "AND awsqueid = queid " +
                "ORDER BY queid, awsid; ";
            SqlCommand sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            Int64 qid = 0;
            String qtext = "";
            int qlevel = 1;
            var answers = new List<QuizAnswer>();
            // TODO Zugriff auf Spalten per name statt Index
            while (sqldata.Read())
            {
                if (qid == 0)
                {
                    qid = sqldata.GetInt64(1);
                    qlevel = sqldata.GetInt32(2);
                    qtext = sqldata.GetString(3);
                }
                // TODO Unterstützung für Bilder importieren
                answers.Add(new QuizAnswer(sqldata.GetInt64(6), sqldata.GetString(7), sqldata.GetBoolean(9), sqldata.GetInt32(8)));
            }
            sqldata.Close();
            if (answers.Count != 0)
            {
                return new Question(qid, qtext, qlevel, answers.ToArray());
            }
            return null;
        }

        public static bool SaveQuestion(Question qc)
        {
            // TODO Speicherfunktion für Questions (und ihre Antworten)
            return false;
        }

        public static User[] GetAllUsers()
        {
            const string sqlStatement = "SELECT usrid,usrLogin, usrPassword, usrIsAdmin " +
                                        "FROM Users;";
            var sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            var users = new List<User>();
            while (sqldata.Read())
            {
                users.Add(new User(sqldata.GetInt32(0), sqldata.GetString(1), sqldata.GetString(2),sqldata.GetBoolean(3)));
            }
            sqldata.Close();
            return users.ToArray();
        }

        public static User GetUser(string login)
        {
            String sqlStatement = "SELECT usrLogin, usrPassword, usrIsAdmin " +
                                  "FROM Users " +
                                  "WHERE usrLogin = '" + login + "';";
            SqlCommand sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            User user = null;
            if (sqldata.Read())
            {
                user = new User(sqldata.GetInt64(1), sqldata.GetString(4), sqldata.GetString(3), sqldata.GetBoolean(2));
            }
            sqldata.Close();
            return user;
        }
    }
}
