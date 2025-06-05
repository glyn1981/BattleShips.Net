
namespace BattleShips.Objects
{
    /// <summary>
    /// Class that initialises the board.
    /// </summary>
    public class BoardInitialiser : IBoardInitialiser
    {
    /// <summary>
    /// Initialises the game board
    /// </summary>
    /// <param name="BOARD_SIZE">the width and height of the board</param>
    /// <param name="board">the board object</param>
        public void InitBoard(int BOARD_SIZE, char[,] board)
        {
            //iterate through the board and set every square to empty
            for (int i = 1; i <= BOARD_SIZE; i++)
            {
                for (int j = 1; j <= BOARD_SIZE; j++)
                {
                    //every square is empty to start with
                    board[i, j] = ' ';
                }
            }
        }


    }
}
