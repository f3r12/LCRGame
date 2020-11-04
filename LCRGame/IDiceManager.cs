using System.Collections.Generic;

namespace LCRGame
{
    public interface IDiceManager
    {
        IGameManager GameManager { get; set; }

        IList<Dice> DiceList { get; set; }

        IDiceCreator DiceCreator { get; set; }

        IChipsManager ChipsManager { get; set; }

        void RollDice();
    }
}