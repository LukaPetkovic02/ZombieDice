using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ZombieDice.Model
{
    public class RollResult : IColor, IValue
    {
        public DIE_COLOR Color { get; private set; }
        public DIE_VALUE Value { get; private set; }
        
        public RollResult(DIE_COLOR color, DIE_VALUE value)
        {
            Color = color;
            Value = value;
        }
        
        public Image DisplayDie()
        {
            Image image = new ()
            {
                Height = 50,
                Width = 50,
                Source = new BitmapImage(new Uri($"../../../images/{Color.ToString().ToLower()}_{Value.ToString().ToLower()}.png", UriKind.RelativeOrAbsolute))
            };
            return image;
        }
    }
}
