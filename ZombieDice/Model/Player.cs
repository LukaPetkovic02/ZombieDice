using DieSDK;
using System.Collections.Generic;

namespace ZombieDice.Model
{
    public class Player
    {
        public string Name { get; set; }

        public int BrainCount { get; set; }

        public Roll Roll;
        public Player(string name)
        {
            Name = name;
            BrainCount = 0;
            ICupSetup cupSetup = new BaseCupSetup();
            Roll = new Roll(cupSetup);
        }

        public bool HasPlayerCollected13Brains()
        {
            return BrainCount + Roll.BrainCount + Roll.DoubleBrains.Count*2 >= 13;
        }

        public List<RollResult> Play() // button click - take dice and roll
        {
            List<Die> dice = new List<Die>(); // all runners dice from previous roll are thrown in the next roll
            foreach (RollResult rollResult in Roll.Runners)
            {
                dice.Add(rollResult.Die);
            }
            
            dice.AddRange(DrawDice());
            List<RollResult> diceResult = Roll.RollDice(dice);

            //
            // update stanja playera (Take klasa) ili Turn?
            //

            return diceResult;
        }
        
        public bool Lost()
        {
            int lives = Roll.Helmet ? 4 : 3;
            return Roll.Shotguns.Count + Roll.DoubleShotguns.Count >= lives;
        }

        public List<Die> DrawDice()
        {
            int diceToDraw = 3 - Roll.Runners.Count;
            if (!Roll.Cup.EnoughDiceInCup(diceToDraw))
            {
                Roll.returnAllBrainsToCup();
            }
            
            return Roll.DrawDiceFromCup(diceToDraw);
        }
        public void StoreBrains()
        {
            if (!Lost())
            {
                BrainCount += Roll.BrainCount + Roll.DoubleBrains.Count*2;
                ICupSetup cupSetup = new BaseCupSetup();
                Roll = new Roll(cupSetup);
            }
        }
    }
}
