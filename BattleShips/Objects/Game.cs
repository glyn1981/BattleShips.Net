using BattleShips.Helpers;

namespace BattleShips.Objects
{
    public class Game : IGame
    {
        private const int BOARD_SIZE = 10;
        private readonly char[,] board;
        private readonly List<Ship> ships;
        private readonly List<string> guesses;
        private readonly Random random;
        private readonly IInputValidator inputValidator;
        private readonly IUtils utils;

        public Game(List<Ship> Ships, List<string> Guesses, Random randomiser )
        {
            board = new char[BOARD_SIZE + 1, BOARD_SIZE + 1];
            ships = Ships;
            guesses = Guesses;
            random = randomiser;
        }

        /// <summary>
        /// Starts a new game of Battleships
        /// </summary>
        public void Start()
        {
            //inisitalise the board and ships
            InitBoard();

            if(ships.Count == 0)
            {
                InitShips();
            }   

            //display the board.
            DisplayBoard();
            //get the users guess
            GetGuess();
        }

        /// <summary>
        /// Outputs the game board to the console
        /// </summary>
        public void DisplayBoard()
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

        /// <summary>
        /// Gets the user's guess for the next move
        /// </summary>
        public void GetGuess()
        {
            InputValidator inputValidator = new InputValidator();

            while (true)
            {
                Console.WriteLine("Enter your guess:");
                string? guess = Console.ReadLine()?.ToUpper();

                //make sure the guess is valid
                if (!string.IsNullOrWhiteSpace(guess) && inputValidator.IsValidA1Format(guess))
                {
                    int col = Utils.CharToNumber(guess[0]);
                    int row = int.Parse(guess.Substring(1));

                    //make sure the guess has not already been made
                    if (inputValidator.AlreadyGuessed(guess, guesses))
                    {
                        Console.WriteLine("You have already guessed that position. Please enter a new guess.");
                        continue;
                    }

                    guesses.Add(guess);

                    // check if the guess is a hit
                    if (IsHit(guess))
                    {
                        Console.Clear();
                        Console.WriteLine("Hit!");
                        board[col, row] = 'X';
                        Ship ship = ships.Single(x => x.Positions.Contains(guess));
                        ship.Hit();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Miss!");
                        board[col, row] = 'O';
                    }

                    break; // Exit loop on valid input
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid guess.");
                }
            }
        }

        /// <summary>
        /// Checks if the game is over
        /// </summary>
        public bool CheckGameOver()
        {
            return ships.All(ship => ship.IsSunk);
        }

        /// <summary>
        /// Initializes the game board
        /// </summary>
        private void InitBoard()
        {
            for (int i = 1; i <= BOARD_SIZE; i++)
            {
                for (int j = 1; j <= BOARD_SIZE; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        /// <summary>
        /// Initializes new random ships
        /// </summary>
        private void InitShips()
        {
            ships.Add(new Ship(5, "Battleship", "C"));
            ships.Add(new Ship(4, "Destroyer", "B"));
            ships.Add(new Ship(4, "Destroyer", "B"));

            for (int i = 0; i < ships.Count; i++)
            {
                AddShipToBoard(ships[i]);
            }

        }

        private bool AddShipToBoard(Ship theShip)
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




        /// <summary>
        /// Checks if the guess is a hit
        /// </summary>
        private bool IsHit(string guess)
        {
            return ships.SelectMany(x => x.Positions).Contains(guess);
        }
    }
}