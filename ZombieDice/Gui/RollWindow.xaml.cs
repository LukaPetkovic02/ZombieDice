using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
