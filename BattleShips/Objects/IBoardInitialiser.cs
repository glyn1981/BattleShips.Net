namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the initialisation of the board.
    /// </summary>
    internal interface IBoardInitialiser
    {
        void InitBoard(int BOARD_SIZE, char[,] board);
    }
}