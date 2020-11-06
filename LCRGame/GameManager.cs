using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LCRGame
{
    public class GameManager : IGameManager
    {
        public int NumberOfPlayers { get; set; }

        public ObservableCollection<Player> ListOfPlayers { get; set; }

        public IPlayerCreator PlayerCreator { get; set; }

        public Player CurrentPlayer { get; set; }

        public Player Winner { get; set; }

        public ITurnsManager TurnsManager { get; set; }

        public GameManager(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;

            ListOfPlayers = new ObservableCollection<Player>();
            PlayerCreator = new PlayerCreator();
            TurnsManager = new TurnsManager();
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