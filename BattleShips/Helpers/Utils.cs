namespace BattleShips.Helpers
{
    /// <summary>
    /// Utility class for converting between letters and numbers
    /// </summary>
    public class Utils : IUtils
    {
        /// <summary>
        /// converts a board column letter to a number
        /// </summary>
        public static int CharToNumber(char c)
        {
            c = char.ToUpper(c); // convert to uppercase to handle lowercase inputs
            if (c >= 'A' && c <= 'J')
            {
                return c - 'A' + 1;
            }
            throw new ArgumentException("Input must be a letter between A-J.");
        }
        /// <summary>
        /// converts a board column number to the letter equivalent
        /// </summary>
        public static char NumberToChar(int number)
        {
            if (number < 1 || number > 26)
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 26.");

            return (char)('A' + number - 1);
        }

    }
}
