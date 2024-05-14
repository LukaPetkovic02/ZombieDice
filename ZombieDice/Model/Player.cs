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
            Roll = new Roll();
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
                dice.Add(new Die(rollResult.Color));
            }
            
            dice.AddRange(DrawDice());
            List<RollResult> diceResult = Roll.RollDice(dice);
            return diceResult;
        }

        public bool Lost()
        {
            return Roll.Shotguns.Count >= 3;
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
                Roll = new Roll();
            }
        }
    }
}
