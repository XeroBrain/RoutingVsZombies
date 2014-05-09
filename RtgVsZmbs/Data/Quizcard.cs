namespace RtgVsZmbs.Data
{
    using System.Collections.Generic;

    using RtgVsZmbs.Objects;

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

        private Quizcard(int id, string question, List<QuizAnswer> answers, int maxPoints)
        {
            ID = id;
            Question = question;
            Answers = answers;
            MaximumPoints = maxPoints;
            AlreadyAnswered = false;
        }

        public int ID { get; private set; }

        public string Question { get; private set; }

        public List<QuizAnswer> Answers { get; private set; }

        
    }
}
