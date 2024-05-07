using System.Collections.Generic;
using System.Linq;

namespace ZombieDice.Model
{
    public class Game
    {
        public int NumOfPlayers;
        public List<Player> Players;
        public int IndexTurn;
        public bool LastTurn;

        public Game(int numOfPlayers)
        {
            Players = new List<Player>();
            IndexTurn = 0;
            NumOfPlayers = numOfPlayers;
            LastTurn = false;
        }

        public bool NameExists(string name)
        {
            return Players.Any(p => p.Name == name);
        }
        public void AddPlayer(string name)
        {
            Players.Add(new Player(name));
        }

        public Player DetermineWinner()
        {
            return Players.OrderByDescending(p => p.BrainCount).First();
        }
        public void ChangeTurn()
        {
            IndexTurn = (IndexTurn + 1) % Players.Count;
        }
    }
}
