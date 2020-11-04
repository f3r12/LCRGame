namespace LCRGame
{
    public class Player
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Chips { get; set; }

        public Player Left { get; set; }

        public Player Right { get; set; }

        public bool IsMyTurn { get; set; }

        public Player(int id)
        {
            ID = id;
            Name = "Player " + id;
            Chips = 3;
        }

        public void IncreaseChips()
        {
            this.Chips++;
        }

        public void DecreaseChips()
        {
            this.Chips--;
        }
    }
}