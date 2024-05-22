using System;
using System.Collections.Generic;
using DieSDK;

namespace ZombieDice.Model
{
    public class BaseCupSetup : ICupSetup
    {
        private static IValue[] greenDie = { Values.Brain, Values.Brain, Values.Brain, Values.Step, Values.Step, Values.Shotgun };
        private static IValue[] yellowDie = { Values.Brain, Values.Brain, Values.Step, Values.Step, Values.Shotgun, Values.Shotgun };
        private static IValue[] redDie = { Values.Brain, Values.Step, Values.Step, Values.Shotgun, Values.Shotgun, Values.Shotgun };
        public void Setup(List<Die> dice)
        {
            for (int i = 0; i < 6; i++)
            {
                dice.Add(new Die(Colors.Green, greenDie));
            }

            for (int i = 0; i < 4; i++)
            {
                dice.Add(new Die(Colors.Yellow, yellowDie));
            }

            for (int i = 0; i < 3; i++)
            {
                dice.Add(new Die(Colors.Red, redDie));
            }
        }
    }

    public class CupSetup
    {
        public ICupSetup Build(bool heroes, bool santa)
        {
            ICupSetup setup = new BaseCupSetup();
            if (santa)
            {
                setup = new SantaCupSetup(setup);
            }

            if (heroes)
            {
                setup = new HunkCupSetup(setup);
                setup = new HottieCupSetup(setup);
            }

            return setup;
        }
    }
    public class SantaCupSetup : ICupSetup
    {
        private readonly ICupSetup setup;
        private static IValue[] santaDie = { Values.Brain, Values.Shotgun, Values.Step, Values.DoubleBrain, Values.EnergyDrink, Values.Helmet };
        public SantaCupSetup(ICupSetup setup)
        {
            this.setup = setup;
        }

        public void Setup(List<Die> dice)
        {
            setup.Setup(dice);
            int index = dice.FindIndex(x => x.Color is GreenColor);
            if (index < 0)
            {
                throw new InvalidOperationException();
            }

            dice.RemoveAt(index);
            dice.Add(new Die(Colors.Santa,santaDie));
        }
    }

    public class HunkCupSetup : ICupSetup
    {
        private readonly ICupSetup setup;
        private static IValue[] hunkDie = { Values.Step, Values.Step, Values.Shotgun, Values.Shotgun, Values.DoubleShotgun, Values.DoubleBrain };
        public HunkCupSetup(ICupSetup setup)
        {
            this.setup = setup;
        }

        public void Setup(List<Die> dice)
        {
            setup.Setup(dice);
            int index = dice.FindIndex(x => x.Color is YellowColor);
            if (index < 0)
            {
                throw new InvalidOperationException();
            }

            dice.RemoveAt(index);
            dice.Add(new Die(Colors.Hunk, hunkDie));
        }
    }

    public class HottieCupSetup : ICupSetup
    {
        private readonly ICupSetup setup;
        private static IValue[] hottieDie = { Values.Step, Values.Step, Values.Step, Values.Shotgun, Values.Shotgun, Values.Brain };
        public HottieCupSetup(ICupSetup setup)
        {
            this.setup = setup;
        }

        public void Setup(List<Die> dice)
        {
            setup.Setup(dice);
            int index = dice.FindIndex(x => x.Color is YellowColor);
            if (index < 0)
            {
                throw new InvalidOperationException();
            }

            dice.RemoveAt(index);
            dice.Add(new Die(Colors.Hottie, hottieDie));
        }
    }
}
