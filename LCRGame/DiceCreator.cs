namespace LCRGame
{
    internal class DiceCreator : IDiceCreator
    {
        public Dice CreateDice(int diceId)
        {
            return new Dice(diceId);
        }
    }
}