using DieSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZombieDice.Model;

namespace ZombieDice.Gui
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly Game _game;
        private readonly Player player;
        public GameWindow(Game game)
        {
            _game = game;
            player = _game.Players[_game.IndexTurn];
            InitializeComponent();
            DataContext = _game;
            LabelPlayerName.Content = _game.Players[_game.IndexTurn].Name;
            LabelTotalBrains.Content = _game.Players[_game.IndexTurn].BrainCount;
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            List<RollResult> diceResult = player.Play();
            RollWindow rollWindow = new RollWindow(diceResult);
            rollWindow.ShowDialog();
            player.Roll.Rescue();

            if (player.Lost())
            {
                MessageBoxResult result = MessageBox.Show("You rolled 3 or more shotguns so your turn is over!", "Turn finished", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    rollWindow?.Close();
                    SwitchPlayer();
                }
                player.Roll = new Roll(_game.CupSetup);
            }
            else if (player.HasPlayerCollected13Brains() && !_game.LastTurn)
            {
                _game.LastTurn = true;
                MessageBoxResult result = MessageBox.Show("You have collected 13 brains! Players that played after you have 1 more chance!","Turn finished",MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    rollWindow?.Close();
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
            if (_game.LastTurn && player.Name == _game.Players[^1].Name)
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
            EmptyImages();
            for (int i = 0; i < player.Roll.Brains.Count; i++)
            {
                string relativePath = player.Roll.Brains[i].DisplayDie();
                string fullPath = Path.GetFullPath(relativePath);
                string imageName = $"ImgBrainDice{i+1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }

            for (int i = 0; i < player.Roll.DoubleBrains.Count; i++)
            {
                string relativePath = player.Roll.DoubleBrains[i].DisplayDie();
                string fullPath = Path.GetFullPath(relativePath);
                string imageName = $"ImgBrainDice{i + 1 + player.Roll.Brains.Count}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }
            for (int i = 0; i < player.Roll.Runners.Count; i++)
            {
                string relativePath = player.Roll.Runners[i].DisplayDie();
                string fullPath = Path.GetFullPath(relativePath);
                string imageName = $"ImgStepDice{i + 1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }
            for (int i = 0; i < player.Roll.Shotguns.Count; i++)
            {
                string relativePath = player.Roll.Shotguns[i].DisplayDie();
                string fullPath = Path.GetFullPath(relativePath);
                string imageName = $"ImgShotgunDice{i + 1}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }
            for (int i = 0; i < player.Roll.DoubleShotguns.Count; i++)
            {
                string relativePath = player.Roll.DoubleShotguns[i].DisplayDie();
                string fullPath = Path.GetFullPath(relativePath);
                string imageName = $"ImgShotgunDice{i + 1 + player.Roll.Shotguns.Count}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }

            if (player.Roll.EnergyDrink)
            {
                string relativePath = "../../../images/santa_energydrink.png";
                string fullPath = Path.GetFullPath(relativePath);
                ImgSpecialItem.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }
            else if (player.Roll.Helmet)
            {
                string relativePath = "../../../images/santa_helmet.png";
                string fullPath = Path.GetFullPath(relativePath);
                ImgSpecialItem.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
            }
        }

        private void EmptyImages()
        {
            for (int i = 1; i <= 16; i++)
            {
                string imageName = $"ImgBrainDice{i}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = null;
            }

            for (int i = 1; i <= 3; i++)
            {
                string imageName = $"ImgStepDice{i}";
                Image image = Grid.FindName(imageName) as Image;
                image.Source = null;
            }
        }
    }
}
