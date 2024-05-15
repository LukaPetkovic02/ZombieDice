using System.Collections.Generic;
using DieSDK;

namespace ZombieDice.Model
{
    public class BaseCupSetup : ICupSetup
    {
        public void Setup(List<Die> dice)
        {
            for (int i = 0; i < 6; i++)
            {
                dice.Add(new Die(Colors.Green, Values.Brain));
            }

            for (int i = 0; i < 4; i++)
            {
                dice.Add(new Die(Colors.Yellow, Values.Brain));
            }

            for (int i = 0; i < 3; i++)
            {
                dice.Add(new Die(Colors.Red, Values.Brain));
            }
        }
    }
}
