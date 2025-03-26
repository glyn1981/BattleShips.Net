
namespace BattleShips.Helpers
{   
    /// <summary>
    /// class that handles input validation
    /// </summary>
    public interface IInputValidator
    {
        bool AlreadyGuessed(string input, List<string> guesses);
        bool IsValidA1Format(string input);
    }
}