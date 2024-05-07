using System.Collections.Generic;
using System.Windows;
using ZombieDice.Model;

namespace ZombieDice.Gui
{
    /// <summary>
    /// Interaction logic for RollWindow.xaml
    /// </summary>
    public partial class RollWindow : Window
    {
        public RollWindow(List<Die> dice)
        {
            InitializeComponent();
            Img1.Source = dice[0].DisplayDie().Source;
            Img2.Source = dice[1].DisplayDie().Source;
            Img3.Source = dice[2].DisplayDie().Source;
        }
    }
}
