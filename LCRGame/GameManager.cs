using System;
using System.Collections.Generic;
using System.Linq;

namespace LCRGame
{
    public class GameManager : IGameManager
    {
        public int NumberOfPlayers { get; set; }

        public IList<Player> ListOfPlayers { get; set; }

        public IPlayerCreator PlayerCreator { get; set; }

        public Player CurrentPlayer { get; set; }

        public ITurnsManager TurnsManager { get; set; }

        public bool HasWinner { get; set; }

        public GameManager(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;

            ListOfPlayers = new List<Player>();
            PlayerCreator = new PlayerCreator();
            TurnsManager = new TurnsManager();

            HasWinner = false;
        }

        public void OpenGame()
        {
            Player newPlayer;

            for (int playerId = 1; playerId <= NumberOfPlayers; playerId++)
            {
                newPlayer = PlayerCreator.CreatePlayer(playerId);
                ListOfPlayers.Add(newPlayer);
            }

            Assigner.AssignLeftAndRightPlayers(ListOfPlayers);

            CurrentPlayer = TurnsManager.GetNext(ListOfPlayers, CurrentPlayer);
        }
    }
}