using System.Windows;
using DieSDK;
using ZombieDice.Model;

namespace ZombieDice.Gui
{
    /// <summary>
    /// Interaction logic for NameEntryWindow.xaml
    /// </summary>
    public partial class NameEntryWindow : Window
    {
        private readonly Game _game;
        private int counter = 0;
        public NameEntryWindow(Game game)
        {
            InitializeComponent();
            _game = game;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text.Length > 0 && !_game.NameExists(TextBoxName.Text))
            {
                _game.AddPlayer(TextBoxName.Text);
                if (counter == _game.NumOfPlayers - 1)
                {
                    GameWindow gameWindow = new GameWindow(_game);
                    gameWindow.Show();
                    Close();
                }
                else
                {
                    counter++;
                    LabelName.Content = $"Player {counter + 1} name:";
                    TextBoxName.Clear();
                }
            }
            else if (TextBoxName.Text.Length == 0)
            {
                MessageBox.Show("Name can't be empty! Please try again");
            }
            else
            {
                MessageBox.Show("That name already exists! Please try again with a different name");
            }
        }
    }
}
