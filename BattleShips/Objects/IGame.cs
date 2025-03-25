namespace BattleShips.Objects
{
    public interface IGame
    {
        bool CheckGameOver();
        void NextTurn();
        void Start();
    }
}