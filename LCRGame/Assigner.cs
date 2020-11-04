﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LCRGame
{
    internal class Assigner
    {
        internal static void AssignLeftAndRightPlayers(IList<Player> listOfPlayers)
        {
            Player player;

            for (int i = 1; i <= listOfPlayers.Count; i++)
            {
                player = listOfPlayers.First(p => p.ID == i);
                player.Left = GetLeftPlayer(listOfPlayers, i);
                player.Right = GetRightPlayer(listOfPlayers, i);
            }
        }

        private static Player GetRightPlayer(IList<Player> listOfPlayers, int rightPlayerId)
        {
            if (rightPlayerId == 1)
            {
                return listOfPlayers.First(p => p.ID == listOfPlayers.Count);
            }
            else
            {
                rightPlayerId--;
                return listOfPlayers.First(p => p.ID == rightPlayerId);
            }
        }

        private static Player GetLeftPlayer(IList<Player> listOfPlayers, int leftPlayerId)
        {
            if (listOfPlayers.Count == leftPlayerId)
            {
                return listOfPlayers.First(p => p.ID == 1);
            }
            else
            {
                leftPlayerId++;
                return listOfPlayers.First(p => p.ID == leftPlayerId);
            }
        }
    }
}