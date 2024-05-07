using System;
using System.Collections.Generic;
using System.Linq;

namespace ZombieDice.Model
{
    public sealed class Cup
    {
        private readonly List<Die> dice = new List<Die>();
        private const int NumGreenDice = 6;
        private const int NumYellowDice = 4;
        private const int NumRedDice = 3;
        private static Random random = new Random(); // Singleton

        public Cup() // List<Die>
        {
            dice = new List<Die>();
            for (int i = 0; i < NumGreenDice; i++)
            {
                dice.Add(new Die(DIE_COLOR.GREEN));
            }

            for (int i = 0; i < NumYellowDice; i++)
            {
                dice.Add(new Die(DIE_COLOR.YELLOW));
            }

            for (int i = 0; i < NumRedDice; i++)
            {
                dice.Add(new Die(DIE_COLOR.RED));
            }
                
        }
        public bool EnoughDiceInCup(int numberOfDiceToDraw)
        {
            return numberOfDiceToDraw <= dice.Count;
        }
        public Die PickDie()
        {
            if (dice.Count == 0)
                throw new InvalidOperationException("Cup is empty, cannot pick a die.");

            int index = random.Next(0, dice.Count);
            Die selected = dice.ElementAt(index);
            dice.RemoveAt(index);
            return selected;
        }

        public void ReturnDiceToCup(Die die)
        {
            dice.Add(die);
        }

    }
}
