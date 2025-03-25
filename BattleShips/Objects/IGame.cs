namespace BattleShips.Objects
{
    public interface IGame
    {
        bool CheckGameOver();
        void DisplayBoard();
        void GetGuess();
        void Start();
    }
}