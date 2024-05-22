using System.Collections.Generic;
using System.Windows;
using DieSDK;
using ZombieDice.Gui;
using ZombieDice.Model;

namespace ZombieDice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxNum.ItemsSource = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            int numOfPlayers = (int) ComboBoxNum.SelectedItem;
            
            bool heroes = false, santa = false;
            if (CheckBoxHeroes.IsChecked == true)
            {
                heroes = true;
            }

            if (CheckBoxSanta.IsChecked == true)
            {
                santa = true;
            }

            CupSetup baseCupSetup = new CupSetup();
            ICupSetup cupSetup = baseCupSetup.Build(heroes, santa);
            Game game = new Game(numOfPlayers, cupSetup);
            NameEntryWindow window = new NameEntryWindow(game);
            window.Show();
            Close();
        }
    }
}
