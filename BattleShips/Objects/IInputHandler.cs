
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles user input.
    /// </summary>
    internal interface IInputHandler
    {
        void GetGuess(List<string> guesses, List<Ship> ships, char[,] board);
    }
}