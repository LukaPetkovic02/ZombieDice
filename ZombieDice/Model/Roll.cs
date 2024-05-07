using System.Collections.Generic;
using ZombieDice.Gui;

namespace ZombieDice.Model
{
    public class Roll
    {
        public int BrainCount;
        public List<Die> Brains;
        public List<Die> Runners;
        public List<Die> Shotguns;
        public Cup _cup;
        public RollWindow rollWindow;
        public Roll()
        {
            Brains = new List<Die>();
            Runners = new List<Die>();
            Shotguns = new List<Die>();
            BrainCount = 0;
            initCup();
        }

        public List<Die> DrawDiceFromCup(int numberOfDiceToDraw)
        {
            List<Die> drawnDice = new List<Die>();
            for (int i = 0; i < numberOfDiceToDraw; i++)
            {
                drawnDice.Add(_cup.PickDie());
            }
            
            return drawnDice;
        }

        public void RollDice(List<Die> dice)
        {
            Runners = new List<Die>();
            foreach (Die die in dice)
            {
                RollResult rollResult = die.Roll();
                if (rollResult.Value == DIE_VALUE.BRAIN)
                {
                    BrainCount++;
                    Brains.Add(die);
                }

                if (rollResult.Value == DIE_VALUE.STEP)
                {
                    Runners.Add(die);
                }

                if (rollResult.Value == DIE_VALUE.SHOTGUN)
                {
                    Shotguns.Add(die);
                }
                    
            }

            rollWindow = new RollWindow(dice);
            rollWindow.ShowDialog();
        }

        // special case when there aren't enough dices in the cup
        // and the player wants to keep rolling
        public void returnAllBrainsToCup() 
        {
            foreach (Die die in Brains)
            {
                _cup.ReturnDiceToCup(die);
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

            _cup = new Cup(dice);
        }
    }
}
