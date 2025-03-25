using BattleShips.Helpers;

namespace BattleShips.Objects
{
    class Ship : IShip
    {
        public int Size { get; set; }
        public int Hits { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public List<string> Positions { get; set; }

        private static readonly Random random = new Random();

        public bool IsSunk;

        // Constructor for the ship
        public Ship(int size, string name, string symbol, char[,] board)
        {
            Size = size;
            Hits = 0;
            Name = name;
            Symbol = symbol;
            IsSunk = false;
            Positions = new List<string>();
            AddShipToBoard(board);

        }

        // add the ship to the board in a random position and orientation
        private bool AddShipToBoard(char[,] board)
        {

            int boardSize = board.GetLength(0) - 1;
            bool isPlaced = false;
            int attempts = 0;

            while (!isPlaced && attempts < 100) // prevent infinite loops by limiting attempts
            {
                attempts++;
                bool isHorizontal = random.Next(2) == 0; // pick orientation at random. 0 = horizontal, 1 = vertical
                int startRow = random.Next(boardSize);
                int startCol = random.Next(boardSize);

                // ensure the ship fits within the board boundaries
                if (isHorizontal && startCol + Size > boardSize ||
                    !isHorizontal && startRow + Size > boardSize)
                {
                    continue; // try again if out of bounds
                }

                // check for overlaps
                bool overlap = false;
                for (int i = 1; i <= Size; i++)
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
                for (int i = 1; i <= Size; i++)
                {
                    int row = isHorizontal ? startRow : startRow + i;
                    int col = isHorizontal ? startCol + i : startCol;
                    //  board[col, row] = Symbol[0]; // uncomment to show ship on board
                    Positions.Add($"{Utils.NumberToChar(col)}{row}"); // Store ship position

                }

                isPlaced = true;
            }

            return isPlaced; // true if placed successfully, False otherwise

        }

        //the ship has taken a hit - shiver me timbers.
        public void Hit()
        {
            Hits++;
            if (Hits == Size)
            {
                IsSunk = true;
            }
        }

        //has the ship been hit?
        public bool IsHit(List<string> guesses)
        {
            foreach (var guess in guesses)
            {
                if (Positions.Contains(guess))
                {
                    Hit();
                    return true;
                }
            }
            return false;
        }

    }

}
