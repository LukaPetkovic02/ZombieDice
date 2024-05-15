using DieSDK;
using System.Collections.Generic;

namespace ZombieDice.Model
{
    public class Roll
    {
        private readonly ICupSetup cupSetup;
        public int BrainCount { get; private set; }
        public List<RollResult> Brains { get; private set; }
        public List<RollResult> Runners { get; private set; }
        public List<RollResult> Shotguns { get; private set; }
        public Cup Cup { get; private set; }
        public Roll(ICupSetup cupSetup)
        {
            Brains = new List<RollResult>();
            Runners = new List<RollResult>();
            Shotguns = new List<RollResult>();
            BrainCount = 0;
            this.cupSetup = cupSetup;
            InitCup();
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
                if (rollResult.Value == Values.Brain)
                {
                    BrainCount++;
                    Brains.Add(rollResult);
                }

                if (rollResult.Value == Values.Step)
                {
                    Runners.Add(rollResult);
                }

                if (rollResult.Value == Values.Shotgun)
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
                Cup.ReturnDiceToCup(new Die(rollResult.Color,Values.Brain));
            }
            Brains.Clear();
        }

        private void InitCup()
        {
            List<Die> dice = new List<Die>();
            cupSetup.Setup(dice);
            Cup = new Cup(dice);
        }
    }
}
