using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZombieDice.Gui;

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
            Roll = new Roll(new Cup());
        }

        public bool HasPlayerCollected13Brains()
        {
            return BrainCount + Roll.BrainCount >= 13;
        }

        public void Play() // button click - take dice and roll
        {
            List<Die> dice = Roll.Runners; // all runners dice from previous roll are thrown in the next roll
            dice.AddRange(DrawDice());

            Roll.RollDice(dice);
            //else if (HasPlayerCollected13Brains() && !lastTurn)
            //{
            //    MessageBox.Show("You have collected at least 13 brains!");
            //}
        }

        public bool Lost()
        {
            return Roll.Shotguns.Count >= 3;
        }

        public List<Die> DrawDice()
        {
            int diceToDraw = 3 - Roll.Runners.Count;
            if (!Roll.EnoughDiceInCup(diceToDraw))
                Roll.returnAllBrainsToCup();

            return Roll.DrawDiceFromCup(diceToDraw);
        }
        public void StoreBrains()
        {
            if (!Lost())
            {
                BrainCount += Roll.BrainCount;
                Roll = new Roll(new Cup());
            }
        }
    }
}
