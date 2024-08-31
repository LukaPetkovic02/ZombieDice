using DieSDK;
using System.Collections.Generic;

namespace ZombieDice.Model
{
    public class Player
    {
        public string Name { get; set; }

        public int BrainCount { get; set; }

        public Roll Roll;
        private readonly ICupSetup _cupSetup;
        public Player(string name, ICupSetup cupSetup)
        {
            Name = name;
            BrainCount = 0;
            _cupSetup = cupSetup;
            Roll = new Roll(cupSetup);
        }

        public bool HasPlayerCollected13Brains()
        {
            return BrainCount + Roll.BrainCount >= 13;
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

            return diceResult;
        }
        
        public bool Lost()
        {
            int lives = Roll.Helmet ? 4 : 3;
            return Roll.Shotguns.Count + Roll.DoubleShotguns.Count*2 >= lives;
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
                BrainCount += Roll.BrainCount;
                Roll = new Roll(_cupSetup);
            }
        }
    }
}
