using System.Collections.Generic;
using System.Linq;
using DieSDK;

namespace ZombieDice.Model
{
    public class Game
    {
        public int NumOfPlayers;
        public List<Player> Players { get; set; }
        public int IndexTurn;
        public bool LastTurn;
        public ICupSetup CupSetup;

        public Game(int numOfPlayers, ICupSetup cupSetup)
        {
            Players = new List<Player>();
            IndexTurn = 0;
            NumOfPlayers = numOfPlayers;
            LastTurn = false;
            CupSetup = cupSetup;
        }

        public bool NameExists(string name)
        {
            return Players.Any(p => p.Name == name);
        }
        public void AddPlayer(string name)
        {
            Players.Add(new Player(name, CupSetup));
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
