using System.Collections.Generic;

namespace LCRGame
{
    public interface IChipsManager
    {
        IGameManager GameManager { get; set; }

        IList<Dice> DiceList { get; set; }

        void MoveChips();
    }
}