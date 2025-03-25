
namespace BattleShips.Helpers
{
    public interface IInputValidator
    {
        bool AlreadyGuessed(string input, List<string> guesses);
        bool IsValidA1Format(string input);
    }
}