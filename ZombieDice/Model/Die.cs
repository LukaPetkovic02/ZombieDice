using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ZombieDice.Model
{
    public enum DIE_COLOR
    {
        RED=0,
        YELLOW,
        GREEN
    }

    public enum DIE_VALUE
    {
        BRAIN=0,
        STEP,
        SHOTGUN
    }
    public class Die
    {
        public DIE_COLOR Color { get; private set; }
        public DIE_VALUE Value { get; private set; }
        private static Random random = new Random();
        private const int NumberOfSides = 6;

        private static DIE_VALUE[] greenDie = { DIE_VALUE.BRAIN ,DIE_VALUE.BRAIN,DIE_VALUE.BRAIN,DIE_VALUE.STEP,DIE_VALUE.STEP,DIE_VALUE.SHOTGUN};
        private static DIE_VALUE[] yellowDie = { DIE_VALUE.BRAIN, DIE_VALUE.BRAIN, DIE_VALUE.STEP, DIE_VALUE.STEP, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN };
        private static DIE_VALUE[] redDie = { DIE_VALUE.BRAIN, DIE_VALUE.STEP, DIE_VALUE.STEP, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN, DIE_VALUE.SHOTGUN };
        public Die(){}
        public Die(DIE_COLOR color)
        {
            Color = color;
        }

        public void Roll()
        {
            switch (Color)
            {
                case DIE_COLOR.GREEN:
                    Value = greenDie[random.Next(0, NumberOfSides)];
                    break;
                case DIE_COLOR.YELLOW:
                    Value = yellowDie[random.Next(0, NumberOfSides)];
                    break;
                case DIE_COLOR.RED:
                    Value = redDie[random.Next(0, NumberOfSides)];
                    break;
            }
        }

        public Image DisplayDie()
        {
            Image image = new Image();
            image.Height = 50;
            image.Width = 50;
            image.Source = new BitmapImage(new Uri($"../../../images/{Color.ToString().ToLower()}_{Value.ToString().ToLower()}.png", UriKind.RelativeOrAbsolute));
            return image;
        }
    }
}
