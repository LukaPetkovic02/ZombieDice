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
        public RollWindow(List<RollResult> diceResults)
        {
            InitializeComponent();
            Img1.Source = diceResults[0].DisplayDie().Source;
            Img2.Source = diceResults[1].DisplayDie().Source;
            Img3.Source = diceResults[2].DisplayDie().Source;
        }
    }
}
