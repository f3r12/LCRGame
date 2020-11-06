using System.Collections.Generic;

namespace LCRGame
{
    public class ChipsManager : IChipsManager
    {
        public IGameManager GameManager { get; set; }

        public IList<Dice> DiceList { get; set; }

        public ChipsManager(IGameManager gameManager, IList<Dice> diceList)
        {
            GameManager = gameManager;
            DiceList = diceList;
        }

        public void MoveChips()
        {
            string diceSide;

            foreach (Dice dice in DiceList)
            {
                diceSide = dice.AfterRolledSide.ToUpper();

                if (diceSide == Constants.DOT)
                {
                    continue;
                }

                GameManager.CurrentPlayer.Chips--;

                if (diceSide == Constants.LEFT)
                {
                    GameManager.CurrentPlayer.Left.Chips++;
                }
                else if (diceSide == Constants.RIGHT)
                {
                    GameManager.CurrentPlayer.Right.Chips++;
                }
            }
        }
    }
}