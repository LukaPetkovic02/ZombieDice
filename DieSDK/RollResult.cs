using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieSDK
{
    public class RollResult : IColor, IValue
    {
        public IColor Color { get; private set; }
        public IValue Value { get; private set; }

        public RollResult(IColor color, IValue value)
        {
            Color = color;
            Value = value;
        }

        public string DisplayDie()
        {
            string color="",value="";
            switch (Color)
            {
                case GreenColor:
                    color = "green";
                    break;
                case RedColor:
                    color = "red";
                    break;
                case YellowColor:
                    color = "yellow";
                    break;
            }

            switch (Value)
            {
                case ShotgunValue:
                    value = "shotgun";
                    break;
                case StepValue:
                    value = "step";
                    break;
                case BrainValue:
                    value = "brain";
                    break;
            }
            return $"../../../images/{color}_{value}.png";
        }
    }
}
