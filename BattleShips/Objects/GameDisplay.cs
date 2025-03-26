
namespace BattleShips.Objects
{
    /// <summary>
    /// handles displaying the game
    /// </summary>
    class GameDisplay : IGameDisplay
    {

        /// <summary>
        /// Outputs the game board to the console
        /// </summary>
        /// <param name="ships">A collection of ships</param>
        /// <param name="BOARD_SIZE">The height and width of the board.</param>
        /// <param name="board">The board object</param>
        public void DisplayBoard(List<Ship> ships, int BOARD_SIZE, char[,] board)
        {
            Console.WriteLine($"{ships.Count(x => x.Hits > 0)} ships hit");

            int sunkShipsCount = ships.Count(x => x.IsSunk);
            if (sunkShipsCount > 0)
            {
                Console.WriteLine($"{sunkShipsCount} ships sunk");
            }

            //header row for columns
            Console.WriteLine("   A B C D E F G H I J");

            for (int row = 1; row <= BOARD_SIZE; row++)
            {
                //[row] is the row number

                if (row < 10)
                {
                    Console.Write($"{row}  ");
                }
                else
                {
                    Console.Write($"{row} ");
                }

                for (int col = 1; col <= BOARD_SIZE; col++)
                {
                    Console.Write($"{board[col, row]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
