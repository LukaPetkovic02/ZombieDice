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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZombieDice.Gui;
using ZombieDice.Model;

namespace ZombieDice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxNum.ItemsSource = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            int numOfPlayers = (int) ComboBoxNum.SelectedItem;
            _game = new Game(numOfPlayers);
            NameEntryWindow window = new NameEntryWindow(_game);
            window.Show();
            Close();
        }
    }
}
