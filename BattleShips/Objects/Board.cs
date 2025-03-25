using BattleShips.Helpers;
using System.ComponentModel.Design;

namespace BattleShips.Objects
{
    class Game : IGame
    {
        private const int BOARD_SIZE = 10;
        private char[,] board = new char[BOARD_SIZE + 1, BOARD_SIZE + 1];
        private List<Ship> ships = new List<Ship>();
        private List<string> guesses = new List<string>();

        /// <summary>
        /// Starts a new game of Battleships
        /// </summary>
        public void Start()
        {
            //inisitalise the board and ships
            InitBoard();
            InitShips();
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
                string? guess = Console.ReadLine();

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
            ships.Add(new Ship(5, "Battleship", "C", board));
            ships.Add(new Ship(4, "Destroyer", "B", board));
            ships.Add(new Ship(4, "Destroyer", "B", board));
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