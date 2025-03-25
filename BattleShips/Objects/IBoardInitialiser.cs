namespace BattleShips.Objects
{
    internal interface IBoardInitialiser
    {
        void InitBoard(int BOARD_SIZE, char[,] board);
    }
}