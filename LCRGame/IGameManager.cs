using System.Collections.Generic;

namespace LCRGame
{
    public interface IGameManager
    {
        int NumberOfPlayers { get; set; }

        IList<Player> ListOfPlayers { get; set; }

        IPlayerCreator PlayerCreator { get; set; }

        Player CurrentPlayer { get; set; }

        ITurnsManager TurnsManager { get; set; }

        bool HasWinner { get; set; }

        void OpenGame();
    }
}