namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the initialisation of the board.
    /// </summary>
    public interface IBoardInitialiser
    {
        void InitBoard(int BOARD_SIZE, char[,] board);
    }
}