using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.GameEngine
{
    using System.Security.Policy;

    using RtgVsZmbs.Objects;

    internal class FieldEngine
    {


        //Takes a List of Quizcards and arranges them into an Array
        //BUT only if the number of elements inside the list are at least the amount of horizontal times the vertical amount of wished elements
        public Quizcard[,] GenerateQuizcardArray(List<Quizcard> cardList, int horizontal, int vertical)
        {
            if (cardList.Count >= (horizontal * vertical))
            {
                var cardArr = new Quizcard[horizontal, vertical];
                for (int i = 0; i < horizontal; i++)
                {
                    for (int j = 0; j < vertical; j++)
                    {
                        cardArr[i, j] = cardList.First();
                        cardList.RemoveAt(0);
                    }
                }
                return cardArr;
            }
            return null;
        }

    }
}
