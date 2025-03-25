
namespace BattleShips.Objects
{
    //handles board initialisation
    class BoardInitialiser : IBoardInitialiser
    {
        /// <summary>
        /// Initializes the game board
        /// </summary>
        public void InitBoard(int BOARD_SIZE, char[,] board)
        {
            for (int i = 1; i <= BOARD_SIZE; i++)
            {
                for (int j = 1; j <= BOARD_SIZE; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }


    }
}
