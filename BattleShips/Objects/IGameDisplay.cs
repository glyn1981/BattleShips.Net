
namespace BattleShips.Objects
{
    internal interface IGameDisplay
    {
        void DisplayBoard(List<Ship> ships, int BOARD_SIZE, char[,] board);
    }
}