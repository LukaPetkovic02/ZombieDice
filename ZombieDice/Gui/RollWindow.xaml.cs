using System;
using DieSDK;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

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
            string relativePath1 = diceResults[0].DisplayDie();
            string fullPath1 = Path.GetFullPath(relativePath1);
            string relativePath2 = diceResults[1].DisplayDie();
            string fullPath2 = Path.GetFullPath(relativePath2);
            string relativePath3 = diceResults[2].DisplayDie();
            string fullPath3 = Path.GetFullPath(relativePath3);
            Img1.Source = new BitmapImage(new Uri(fullPath1,UriKind.RelativeOrAbsolute));
            Img2.Source = new BitmapImage(new Uri(fullPath2, UriKind.RelativeOrAbsolute));
            Img3.Source = new BitmapImage(new Uri(fullPath3, UriKind.RelativeOrAbsolute));
        }
    }
}
