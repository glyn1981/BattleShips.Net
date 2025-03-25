using System.Text.RegularExpressions;


namespace BattleShips.Helpers
{
    public class InputValidator
    {
        /// <summary>
        /// validates the input format for the game board
        /// </summary>
        public bool IsValidA1Format(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2 || input.Length > 3)
                return false;

            // Regular expression to check format: Letter A-J followed by number 1-10
            Regex regex = new Regex(@"^[A-J](10|[1-9])$");
            return regex.IsMatch(input);
        }
        /// <summary>
        /// checks to see if the guess has already been made
        /// </summary>
        public bool AlreadyGuessed(string input, List<string> guesses)
        {
            return guesses.Contains(input);
        }

    }
}
