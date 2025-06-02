
using BattleShips.Helpers;

namespace BattleShips.Objects
{
    /// <summary>
    /// Handles user input.
    /// </summary>
    public interface IInputHandler
    {
        void GetGuess(List<string> guesses, List<Ship> ships, char[,] board,
            IUtils utils,
            IInputValidator inputValidator,
            IShipStrikeChecker shipStrikeChecker,
            IUserInterface userInterface);
    }
}