using System.Collections.Generic;
using ZombieDice.Gui;

namespace ZombieDice.Model
{
    public class Roll
    {
        public int BrainCount { get; private set; }
        public List<RollResult> Brains { get; private set; }
        public List<RollResult> Runners { get; private set; }
        public List<RollResult> Shotguns { get; private set; }
        public Cup Cup { get; private set; }
        public Roll()
        {
            Brains = new List<RollResult>();
            Runners = new List<RollResult>();
            Shotguns = new List<RollResult>();
            BrainCount = 0;
            initCup();
        }

        public List<Die> DrawDiceFromCup(int numberOfDiceToDraw)
        {
            List<Die> drawnDice = new List<Die>();
            for (int i = 0; i < numberOfDiceToDraw; i++)
            {
                drawnDice.Add(Cup.PickDie());
            }

            return drawnDice;
        }

        public List<RollResult> RollDice(List<Die> dice)
        {
            Runners.Clear();
            List<RollResult> diceResults = new List<RollResult>();
            foreach (Die die in dice)
            {
                RollResult rollResult = die.Roll();
                if (rollResult.Value == DIE_VALUE.BRAIN)
                {
                    BrainCount++;
                    Brains.Add(rollResult);
                }

                if (rollResult.Value == DIE_VALUE.STEP)
                {
                    Runners.Add(rollResult);
                }

                if (rollResult.Value == DIE_VALUE.SHOTGUN)
                {
                    Shotguns.Add(rollResult);
                }
                diceResults.Add(rollResult);
            }
            return diceResults;
        }

        // special case when there aren't enough dices in the cup
        // and the player wants to keep rolling
        public void returnAllBrainsToCup() 
        {
            foreach (RollResult rollResult in Brains)
            {
                Cup.ReturnDiceToCup(new Die(rollResult.Color));
            }
            Brains.Clear();
        }

        private void initCup()
        {
            List<Die> dice = new List<Die>();
            for (int i = 0; i < 6; i++)
            {
                dice.Add(new Die(DIE_COLOR.GREEN));
            }

            for (int i = 0; i < 4; i++)
            {
                dice.Add(new Die(DIE_COLOR.YELLOW));
            }

            for (int i = 0; i < 3; i++)
            {
                dice.Add(new Die(DIE_COLOR.RED));
            }

            Cup = new Cup(dice);
        }
    }
}
