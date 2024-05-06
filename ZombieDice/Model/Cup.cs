using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice.Model
{
    public class Cup
    {
        public List<Die> Dice;
        private const int NumGreenDice = 6;
        private const int NumYellowDice = 4;
        private const int NumRedDice = 3;
        private static Random random = new Random();

        public Cup()
        {
            Dice = new List<Die>();
            for (int i = 0; i < NumGreenDice; i++)
                Dice.Add(new Die(DIE_COLOR.GREEN));
            for(int i = 0; i < NumYellowDice; i++)
                Dice.Add(new Die(DIE_COLOR.YELLOW));
            for(int i = 0; i < NumRedDice; i++)
                Dice.Add(new Die(DIE_COLOR.RED));
        }

        public Die PickDie()
        {
            if (Dice.Count == 0)
                throw new InvalidOperationException("Cup is empty, cannot pick a die.");

            int index = random.Next(0, Dice.Count);
            Die selected = Dice.ElementAt(index);
            Dice.RemoveAt(index);
            return selected;
        }

        public void ReturnDiceToCup(Die die)
        {
            Dice.Add(die);
        }

    }
}
