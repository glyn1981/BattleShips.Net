namespace BattleShips.Helpers
{
    /// <summary>
    /// Utility class for converting between letters and numbers
    /// </summary>
    public interface IUtils
    {
         abstract int CharToNumber(char c);
         abstract char NumberToChar(int number);
    }
}