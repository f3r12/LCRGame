using System.Collections.Generic;
using System.Threading;

namespace LCRGame
{
    internal class DiceManager : IDiceManager
    {
        public IGameManager GameManager { get; set; }

        public IList<Dice> DiceList { get; set; }

        public IDiceCreator DiceCreator { get; set; }

        public IChipsManager ChipsManager { get; set; }

        public DiceManager(IGameManager gameManager)
        {
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
            foreach (Dice dice in DiceList)
            {
                //Thread.Sleep(500);
                int sideId = new System.Random().Next(1, 7);
                dice.ChooseSide(sideId);
            }

            ChipsManager.MoveChips();

            WinnerChecker.Check(GameManager);
        }
    }
}