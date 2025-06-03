namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the game logic.
    /// </summary>
    public interface IGame
    {
        void NextTurn();
        void Start();
    }
}