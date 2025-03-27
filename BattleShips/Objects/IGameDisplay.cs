
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the user interface
    /// </summary>
    public interface IGameDisplay
    {
        void DisplayBoard(List<Ship> ships, int BOARD_SIZE, char[,] board);
    }
}