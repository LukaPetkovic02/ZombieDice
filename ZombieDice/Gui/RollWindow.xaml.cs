using System;
using DieSDK;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

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
            Img1.Source = new BitmapImage(new Uri(diceResults[0].DisplayDie(),UriKind.RelativeOrAbsolute));
            Img2.Source = new BitmapImage(new Uri(diceResults[1].DisplayDie(), UriKind.RelativeOrAbsolute));
            Img3.Source = new BitmapImage(new Uri(diceResults[2].DisplayDie(), UriKind.RelativeOrAbsolute));
        }
    }
}
