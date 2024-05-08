using System.Windows;
using System.Windows.Controls;
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
            player.Play();
            if (player.Lost())
            {
                MessageBoxResult result = MessageBox.Show("You rolled 3 or more shotguns so your turn is over!", "Turn finished", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    player.Roll.rollWindow?.Close();
                    SwitchPlayer();
                }
                player.Roll = new Roll();
            }
            else if (player.HasPlayerCollected13Brains() && !_game.LastTurn)
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

        private void EmptyImages()
        {
            ImgStepDice1.Source = null;
            ImgStepDice2.Source = null;
            ImgStepDice3.Source = null;
            ImgBrainDice1.Source = null;
            ImgBrainDice2.Source = null;
            ImgBrainDice3.Source = null;
            ImgBrainDice4.Source = null;
            ImgBrainDice5.Source = null;
            ImgBrainDice6.Source = null;
            ImgBrainDice7.Source = null;
            ImgBrainDice8.Source = null;
            ImgBrainDice9.Source = null;
            ImgBrainDice10.Source = null;
            ImgBrainDice11.Source = null;
            ImgBrainDice12.Source = null;
            ImgBrainDice13.Source = null;
            ImgBrainDice14.Source = null;
            ImgBrainDice15.Source = null;
            ImgBrainDice16.Source = null;
        }
    }
}
