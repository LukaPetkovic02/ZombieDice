using DieSDK;
using System.Collections.Generic;

namespace ZombieDice.Model
{
    public class Roll
    {
        public int BrainCount { get; private set; }
        public List<RollResult> Brains { get; private set; }
        public List<RollResult> Runners { get; private set; }
        public List<RollResult> Shotguns { get; private set; }
        public List<RollResult> DoubleShotguns { get; private set; }
        public List<RollResult> DoubleBrains { get; private set; }
        public bool Helmet { get; private set; }
        public bool EnergyDrink { get; private set; }
        public Cup Cup { get; private set; }
        public Roll(ICupSetup cupSetup)
        {
            Brains = new List<RollResult>();
            Runners = new List<RollResult>();
            Shotguns = new List<RollResult>();
            DoubleShotguns = new List<RollResult>();
            DoubleBrains = new List<RollResult>();
            BrainCount = 0;
            Helmet = false;
            EnergyDrink = false;
            Cup = new Cup(cupSetup);
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
                    Brains.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                }

                if (rollResult.Value == Values.Step)
                {
                    if (EnergyDrink && rollResult.Color == Colors.Green)
                    {
                        BrainCount++;
                        Brains.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                    }
                    else
                    {
                        Runners.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                    }
                }

                if (rollResult.Value == Values.Shotgun)
                {
                    Shotguns.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                }

                if (rollResult.Value == Values.DoubleBrain)
                {
                    BrainCount += 2;
                    DoubleBrains.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                }

                if (rollResult.Value == Values.DoubleShotgun)
                {
                    DoubleShotguns.Add(new RollResult(rollResult.Color, rollResult.Value, die));
                }

                if (rollResult.Value == Values.Helmet)
                {
                    Helmet = true;
                }

                if (rollResult.Value == Values.EnergyDrink)
                {
                    EnergyDrink = true;
                }
                diceResults.Add(new RollResult(rollResult.Color, rollResult.Value, die));
            }
            return diceResults;
        }

        
        // special case when there aren't enough dices in the cup
        // and the player wants to keep rolling
        public void returnAllBrainsToCup()
        {
            foreach (RollResult rollResult in Brains)
            {
                if (rollResult.Color != Colors.Santa)
                {
                    Cup.ReturnDiceToCup(rollResult.Die);
                }
            }

            foreach (RollResult rollResult in DoubleBrains)
            {
                if (rollResult.Color != Colors.Santa)
                {
                    Cup.ReturnDiceToCup(rollResult.Die);
                }
            }
            Brains.RemoveAll(rollResult => rollResult.Color != Colors.Santa);
            DoubleBrains.RemoveAll(rollResult => rollResult.Color != Colors.Santa);
        }
    }
}
