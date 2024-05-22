using DieSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ZombieDice.Model
{
    public sealed class Cup
    {
        public readonly List<Die> dice = new List<Die>();
        public Cup(ICupSetup cupSetup)
        {
            cupSetup.Setup(dice);
            MessageBox.Show(cupSetup.GetType().Name);
            //foreach (Die die in dice)
            //{
            //    MessageBox.Show($"{die.Color}");
            //}
        }
        public bool EnoughDiceInCup(int numberOfDiceToDraw)
        {
            return numberOfDiceToDraw <= dice.Count;
        }
        public Die PickDie()
        {
            if (dice.Count == 0)
            {
                throw new InvalidOperationException("Cup is empty, cannot pick a die.");
            }

            int index = RandomGenerator.Instance.Next(dice.Count);
            Die selected = dice.ElementAt(index);
            dice.RemoveAt(index);
            return selected;
        }

        public void ReturnDiceToCup(Die die)
        {
            dice.Add(die);
        }

    }
}
