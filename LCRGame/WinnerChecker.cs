using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace LCRGame
{
    internal class WinnerChecker
    {
        internal static void Check(IGameManager gameManager, StringBuilder log)
        {
            int playersWithChips = gameManager.ListOfPlayers.Count(p => p.Chips >= 1);

            if (playersWithChips == 1)
            {
                gameManager.Winner = gameManager.ListOfPlayers.First(p => p.Chips >= 1);

                log.AppendLine(string.Format(Constants.WINNER_MSG, gameManager.Winner));
            }
            else
            {
                gameManager.CurrentPlayer = gameManager.TurnsManager.GetNext(gameManager.ListOfPlayers, gameManager.CurrentPlayer);
            }
        }
    }
}