using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LCRGame
{
    internal class DiceManager : IDiceManager
    {
        public IGameManager GameManager { get; set; }

        public IList<Dice> DiceList { get; set; }

        public IDiceCreator DiceCreator { get; set; }

        public IChipsManager ChipsManager { get; set; }

        private StringBuilder Log;

        public DiceManager(IGameManager gameManager, StringBuilder log)
        {
            Log = log;
            GameManager = gameManager;
            DiceList = new List<Dice>();
            DiceCreator = new DiceCreator();

            Dice newDice;
            int chipsCount = GameManager.CurrentPlayer.Chips > 3 ? 3 : GameManager.CurrentPlayer.Chips;

            for (int diceId = 1; diceId <= chipsCount; diceId++)
            {
                newDice = DiceCreator.CreateDice(diceId);
                DiceList.Add(newDice);
            }

            ChipsManager = new ChipsManager(GameManager, DiceList);
        }

        public void RollDice()
        {
            Log.AppendLine(string.Format(Constants.WHOS_TURN_IS_IT_MSG, GameManager.CurrentPlayer.Name, DiceList.Count));

            foreach (Dice dice in DiceList)
            {
                Thread.Sleep(10);
                int sideId = new System.Random().Next(1, 7);
                dice.ChooseSide(sideId);

                Log.AppendLine(string.Format(Constants.AFTER_ROLLING_DICES_MSG, dice.ID, dice.AfterRolledSide));
            }

            ChipsManager.MoveChips();

            int dotDiceCount = DiceList.Count(d => d.AfterRolledSide.ToUpper() == Constants.DOT);

            if (dotDiceCount == DiceList.Count)
            {
                Log.AppendLine(string.Format(Constants.KEEPING_CHIPS_MSG));
            }
            else
            {
                Log.AppendLine(string.Format(Constants.MOVING_CHIPS_MSG));
            }

            WinnerChecker.Check(GameManager, Log);
        }
    }
}