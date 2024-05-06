using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZombieDice.Model;

namespace ZombieDice.Gui
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game _game;
        private Player player;
        public GameWindow(Game game)
        {
            _game = game;
            player = _game.Players[_game.IndexTurn];
            InitializeComponent();
            DataContext = player;
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
            if (player.Lost())
            {
                MessageBoxResult result = MessageBox.Show("You rolled 3 or more shotguns so your turn is over!", "Turn finished", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    player.Roll.rollWindow?.Close();
                    SwitchPlayer();
                }
                player.Roll = new Roll(new Cup());
            }else if (player.HasPlayerCollected13Brains() && !_game.LastTurn)
            {
                _game.LastTurn = true;
                MessageBoxResult result = MessageBox.Show("You have collected 13 brains! Players that played after you have 1 more chance!","Turn finished",MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    player.Roll.rollWindow?.Close();
                    player.StoreBrains();
                    SwitchPlayer();
                }
            }
            UpdateDiceView();
        }

        private void BtnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            player.StoreBrains();
            SwitchPlayer();
        }

        private void SwitchPlayer()
        {
            if (_game.LastTurn && player.Name == _game.Players[_game.Players.Count - 1].Name)
            {
                Player winner = _game.DetermineWinner();
                MessageBox.Show($"GAME IS OVER! THE WINNER IS {winner.Name}");
                Close();
            }
            else
            {
                _game.ChangeTurn();
                GameWindow nextGameWindow = new GameWindow(_game);
                nextGameWindow.Show();
                Close();
            }
        }

        private void UpdateDiceView()
        {
            ImgStepDice1.Source = null;
            ImgStepDice2.Source = null;
            ImgStepDice3.Source = null;
            for (int i = 0; i < player.Roll.Brains.Count; i++)
            {
                string imageName = $"ImgBrainDice{i+1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = player.Roll.Brains[i].DisplayDie().Source;
            }
            for (int i = 0; i < player.Roll.Runners.Count; i++)
            {
                string imageName = $"ImgStepDice{i + 1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = player.Roll.Runners[i].DisplayDie().Source;
            }
            for (int i = 0; i < player.Roll.Shotguns.Count; i++)
            {
                string imageName = $"ImgShotgunDice{i + 1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = player.Roll.Shotguns[i].DisplayDie().Source;
            }
        }
    }
}
