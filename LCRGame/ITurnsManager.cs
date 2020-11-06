using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LCRGame
{
    public interface ITurnsManager
    {
        Player GetNext(ObservableCollection<Player> listOfPlayers, Player currentPlayer);
    }
}