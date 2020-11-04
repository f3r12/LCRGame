namespace LCRGame
{
    internal class PlayerCreator : IPlayerCreator
    {
        public Player CreatePlayer(int playerId)
        {
            return new Player(playerId);
        }
    }
}