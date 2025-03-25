
namespace BattleShips.Objects
{
    internal interface IInputHandler
    {
        void GetGuess(List<string> guesses, List<Ship> ships, char[,] board);
    }
}