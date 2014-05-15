using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RtgVsZmbs.Data;

namespace RtgVsZmbs.Objects
{
    internal class SQLFactory
    {
        private static String serveraddress = "85.183.21.62";
        private static String userid = "RVZLogin";
        private static String password = "ZombieNation21!";
        private static String dbname = "RoutingVsZombie";
        private static String appname = "RoutingVsZombies_Client";
        private static SqlConnection _sqlcon = null;

        private SQLFactory()
        {
            // this is an utility class and must not be extended
        }

        public static void initConnection()
        {
            var conBuilder = new SqlConnectionStringBuilder();
            conBuilder.DataSource = serveraddress;
            conBuilder.UserID = userid;
            conBuilder.Password = password;
            conBuilder.ApplicationName = appname;
            conBuilder.ApplicationIntent = ApplicationIntent.ReadWrite;
            _sqlcon = new SqlConnection(conBuilder.ConnectionString);
            _sqlcon.Open();
        }

        public static void closeConnection()
        {
            _sqlcon.Close();
            _sqlcon = null;
        }

        public static Question[] getAllQuestions()
        {
            String sqlStatement = "SELECT queid FROM Questions;";
            List<Question> questions = new List<Question>();
            SqlCommand sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            List<Int64> ids = new List<Int64>();
            while (sqldata.Read())
            {
                ids.Add(sqldata.GetInt64(1));
            }
            sqldata.Close();
            foreach (Int64 id in ids)
            {
                questions.Add(getQuestion(id));
            }
            return questions.ToArray();
        }

        public static Question getQuestion(Int64 id)
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
            List<QuizAnswer> answers = new List<QuizAnswer>();
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

        public static bool saveQuestion(Question qc)
        {
            // TODO Speicherfunktion für Questions (und ihre Antworten)
            return false;
        }

        public static User[] getAllUsers()
        {
            String sqlStatement = "SELECT usrLogin, usrPassword, usrIsAdmin " +
                                  "FROM Users;";
            SqlCommand sqlcommand = _sqlcon.CreateCommand();
            sqlcommand.CommandText = sqlStatement;
            SqlDataReader sqldata = sqlcommand.ExecuteReader();
            List<User> users = new List<User>();
            if (sqldata.Read())
            {
                users.Add(new User(sqldata.GetInt64(1), sqldata.GetString(4), sqldata.GetString(3),
                    sqldata.GetBoolean(2)));
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
