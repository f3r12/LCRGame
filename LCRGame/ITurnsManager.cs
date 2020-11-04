using System.Collections.Generic;

namespace LCRGame
{
    public interface ITurnsManager
    {
        Player GetNext(IList<Player> listOfPlayers, Player currentPlayer);
    }
}