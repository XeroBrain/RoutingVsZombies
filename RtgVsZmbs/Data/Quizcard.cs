﻿namespace RtgVsZmbs.Data
{
    using System.Collections.Generic;
    using RtgVsZmbs.Objects;
    using System.Data.SqlClient;
    using System.Security.Cryptography;
    using System.Data;
    using System;


    class Quizcard
    {
        public int MaximumPoints { get; private set; }

        private int _achievedPoints;

        public int AchievedPoints {
            get
            {
                return _achievedPoints;
            }
            //Sollte die Frage bearbeitet worden sein, wird das AlreadyAnswered flag true gesetzt
            set
            {
                if (value > 0)
                {
                    AlreadyAnswered = true;
                }
                _achievedPoints = value;
                ;
            } }

        public bool AlreadyAnswered { get; private set; }

        public Quizcard(int level) { 
        Level = level; }

        public int ID { get; private set; }

        public string Question { get; private set; }

        public int Level { get; private set; }

        public List<QuizAnswer> Answers { get; private set; }

        public bool getRandomQuestion()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=85.183.21.62,1433;" + "Initial Catalog=RoutingVsZombie;" + "User id=RVZLogin;" + "Password=ZombieNation21!;"))
            {
                DataTable dataTableQuestion = new DataTable();
                SqlDataAdapter adapterQuestion = new SqlDataAdapter();
                adapterQuestion.SelectCommand = new SqlCommand("SELECT top 1 queid,queQuestion FROM Questions where queLevel=@Level ORDER BY newid()", connection);
                adapterQuestion.SelectCommand.Parameters.Add("@Level", SqlDbType.Int);
                adapterQuestion.SelectCommand.Parameters["@Level"].Value = Level;
                adapterQuestion.Fill(dataTableQuestion);

                if (dataTableQuestion.Rows.Count != 1) return false;

                Question = (string)dataTableQuestion.Rows[0]["queQuestion"];
                ID = (int)dataTableQuestion.Rows[0]["queid"];

                DataTable dataTableAnswers = new DataTable();
                SqlDataAdapter adapterAnswers = new SqlDataAdapter();
                adapterAnswers.SelectCommand = new SqlCommand("Select awsid,awsAnswer,awsTypeid,awsIsCorrect from Answers where awsqueid=@Queid", connection);
                adapterAnswers.SelectCommand.Parameters.Add("@Queid", SqlDbType.Int);
                adapterAnswers.SelectCommand.Parameters["@Queid"].Value = ID;
                adapterAnswers.Fill(dataTableAnswers);
                if (dataTableQuestion.Rows.Count < 1) return false;
                Answers = new List<QuizAnswer>();
                foreach(DataRow answer in dataTableAnswers.Rows)
                {
                    Answers.Add(new QuizAnswer((int)answer["awsid"], (string)answer["awsAnswer"], (bool)answer["awsIsCorrect"], ConvertToInt(answer["awsTypeid"])));
                }
            }
            return true;
        }

        private int ConvertToInt(object zahl)
        {
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(zahl);
                return temp;
            }
            catch
            {
                return 0;
            }
        }
    }
}
