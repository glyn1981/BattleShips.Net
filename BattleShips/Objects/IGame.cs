namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the game logic.
    /// </summary>
    public interface IGame
    {
        bool CheckGameOver();
        void NextTurn();
        void Start();
    }
}