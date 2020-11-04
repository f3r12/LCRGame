using System;
using System.Collections.Generic;
using System.Linq;

namespace LCRGame
{
    internal class TurnsManager : ITurnsManager
    {
        public Player GetNext(IList<Player> listOfPlayers, Player currentPlayer)
        {
            Player nextPlayer = null;

            if (currentPlayer == null)
            {
                nextPlayer = listOfPlayers.First(p => p.ID == 1);
            }
            else
            {
                currentPlayer.IsMyTurn = false;
                nextPlayer = GetPossibleNextPlayer(listOfPlayers, currentPlayer.ID);
            }

            nextPlayer.IsMyTurn = true;

            return nextPlayer;
        }

        private Player GetPossibleNextPlayer(IList<Player> listOfPlayers, int currentId)
        {
            Player nextPlayer = null;

            if (listOfPlayers.Count == currentId)
            {
                nextPlayer = listOfPlayers.First(p => p.ID == 1);
                currentId = 1;
            }
            else
            {
                currentId++;
                nextPlayer = listOfPlayers.First(p => p.ID == currentId);
            }

            if (nextPlayer.Chips > 0)
            {
                return nextPlayer;
            }
            else
            {
                return GetPossibleNextPlayer(listOfPlayers, currentId);
            }
        }
    }
}