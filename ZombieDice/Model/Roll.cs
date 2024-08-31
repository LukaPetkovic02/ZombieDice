using DieSDK;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
                        Brains.Add(new RollResult(rollResult.Color, Values.Brain, die));
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

        public void Rescue()
        {
            // if Roll contains hunk double brain and hottie shotgun,
            // then return hunk die to cup
            int index1 = DoubleBrains.FindIndex(x => x.Color is HunkColor);
            //DoubleBrains.Any(m=> m.Color is HunkColor);//
            int index2 = Shotguns.FindIndex(x => x.Color is HottieColor);
            if (DoubleBrains.Any(m => m.Color is HunkColor) && index2 >= 0) // both exist
            {
                MessageBox.Show("Hottie saved hunk! Hunk brains are returned to cup");
                Cup.ReturnDiceToCup(DoubleBrains[index1].Die);
                DoubleBrains.RemoveAt(index1);
                BrainCount -= 2;
            }

            // if Roll contains hottie brain and hunk shotgun/double shotgun,
            // then return hottie die to cup
            int index3 = Brains.FindIndex(x => x.Color is HottieColor);
            int index4 = Shotguns.FindIndex(x => x.Color is HunkColor);
            int index5 = DoubleShotguns.FindIndex(x => x.Color is HunkColor);
            if (index3 >= 0 && (index4 >= 0 || index5 >= 0))
            {
                MessageBox.Show("Hunk saved hottie! Returning hottie brain to cup!");
                Cup.ReturnDiceToCup(Brains[index3].Die);
                Brains.RemoveAt(index3);
                BrainCount--;
            }
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
