namespace BattleShips.Helpers
{
    /// <summary>
    /// Utility class for converting between letters and numbers
    /// </summary>
    public interface IUtils
    {
        static abstract int CharToNumber(char c);
        static abstract char NumberToChar(int number);
    }
}