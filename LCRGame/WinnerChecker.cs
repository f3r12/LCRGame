using System;
using System.Linq;
using System.Windows;

namespace LCRGame
{
    internal class WinnerChecker
    {
        internal static void Check(IGameManager gameManager)
        {
            int playersWithChips = gameManager.ListOfPlayers.Count(p => p.Chips >= 1);

            if (playersWithChips == 1)
            {
                gameManager.HasWinner = true;

                //Player playerWithChips = gameManager.ListOfPlayers.First(p => p.Chips >= 1);

                //MessageBox.Show(string.Format("{0} won!", playerWithChips.Name));

                //Environment.Exit(0);
            }
            else
            {
                gameManager.CurrentPlayer = gameManager.TurnsManager.GetNext(gameManager.ListOfPlayers, gameManager.CurrentPlayer);
            }
        }
    }
}