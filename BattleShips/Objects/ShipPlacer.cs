using BattleShips.Helpers;

namespace BattleShips.Objects
{
    /// <summary>
    /// Places ships on the board
    /// </summary>
    class ShipPlacer


    {
        /// <summary>
        /// Adds a ship to the board
        /// </summary>
        /// <param name="theShip">the ship which we will be adding to the board.</param>
        /// <param name="board">the game board object</param>
        /// <returns></returns>
        public bool AddShipToBoard(Ship theShip, char[,] board, Random random, IUtils utils)
        {
            const int NUMBER_OF_TRIES = 100;
            int boardSize = board.GetLength(0) - 1;
            bool isPlaced = false;
            int attempts = 0;

            while (!isPlaced && attempts < NUMBER_OF_TRIES) // prevent infinite loops by limiting attempts
            {
                attempts++;
                bool isHorizontal = random.Next(2) == 0; // pick orientation at random. 0 = horizontal, 1 = vertical
                int startRow = random.Next(boardSize);
                int startCol = random.Next(boardSize);

                // ensure the ship fits within the board boundaries
                if (isHorizontal && startCol + theShip.Size > boardSize ||
                    !isHorizontal && startRow + theShip.Size > boardSize)
                {
                    continue; // try again if out of bounds
                }

                // check for overlaps
                bool overlap = false;
                for (int i = 1; i <= theShip.Size; i++)
                {
                    int row = isHorizontal ? startRow : startRow + i;
                    int col = isHorizontal ? startCol + i : startCol;
                    if (board[col, row] != ' ') // If not empty, there's an overlap
                    {
                        overlap = true;
                        break;
                    }
                }

                if (overlap) continue; // try again if overlapping

                // place the ship
                for (int i = 1; i <= theShip.Size; i++)
                {
                    int row = isHorizontal ? startRow : startRow + i;
                    int col = isHorizontal ? startCol + i : startCol;
                    theShip.Positions.Add($"{utils.NumberToChar(col)}{row}"); // Store ship position
                    //board[col, row] = 'S'; // uncomment to show ship on board

                }

                isPlaced = true;
            }

            return isPlaced; // true if placed successfully, False otherwise

        }

    }
}
