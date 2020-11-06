using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LCRGame
{
    public interface IGameManager
    {
        int NumberOfPlayers { get; set; }

        ObservableCollection<Player> ListOfPlayers { get; set; }

        IPlayerCreator PlayerCreator { get; set; }

        Player CurrentPlayer { get; set; }

        Player Winner { get; set; }

        ITurnsManager TurnsManager { get; set; }

        void OpenGame();
    }
}