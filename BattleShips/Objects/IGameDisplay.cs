
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the user interface
    /// </summary>
    internal interface IGameDisplay
    {
        void DisplayBoard(List<Ship> ships, int BOARD_SIZE, char[,] board);
    }
}