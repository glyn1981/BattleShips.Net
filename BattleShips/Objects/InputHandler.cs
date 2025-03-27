using BattleShips.Helpers;
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles user input.
    /// </summary>
    public class InputHandler : IInputHandler
    {


        /// <summary>
        /// Gets the user's guess for the next move
        /// </summary>
        /// <param name="guesses">a list of guesses</param>
        /// <param name="ships">a list of ships</param>
        /// <param name="board">the board object</param>
        public void GetGuess(List<string> guesses, List<Ship> ships, char[,] board, 
            IUtils utils, 
            IInputValidator inputValidator,
            IShipStrikeChecker shipStrikeChecker
            )
        {
      
 
            while (true)
            {
                //get the users guess and convert it to the correct format
                Console.WriteLine("Enter your guess:");
                string? guess = Console.ReadLine()?.ToUpper();

                //make sure the guess is valid
                if (!string.IsNullOrWhiteSpace(guess) && inputValidator.IsValidA1Format(guess))
                {
                    //convert the guess to a column and row
                    int col = utils.CharToNumber(guess[0]);
                    int row = int.Parse(guess.Substring(1));

                    //make sure the guess has not already been made
                    if (inputValidator.AlreadyGuessed(guess, guesses))
                    {
                        Console.WriteLine("You have already guessed that position. Please enter a new guess.");
                        continue;
                    }
                    //add the guess to the list of guesses
                    guesses.Add(guess);

                    // check if the guess is a hit
                    if (shipStrikeChecker.IsHit(guess, ships))
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

    }
}
