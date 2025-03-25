namespace BattleShips
{
    internal interface IGame
    {
        bool CheckGameOver();
        void DisplayBoard();
        void GetGuess();
        void Start();
    }
}