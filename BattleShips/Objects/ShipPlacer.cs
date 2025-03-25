using BattleShips.Helpers;
using System;
using System.Runtime.CompilerServices;

namespace BattleShips.Objects
{
    class ShipPlacer
    {
     
        public bool AddShipToBoard(Ship theShip, char[,] board)
        {
            const int NUMBER_OF_TRIES = 100;
            Random random = new Random();
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
                    theShip.Positions.Add($"{Utils.NumberToChar(col)}{row}"); // Store ship position
                    //board[col, row] = 'S'; // uncomment to show ship on board

                }

                isPlaced = true;
            }

            return isPlaced; // true if placed successfully, False otherwise

        }

    }
}
