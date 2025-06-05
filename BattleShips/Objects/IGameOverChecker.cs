
namespace BattleShips.Objects
{
    internal interface IGameOverChecker
    {
        bool GameOver(List<Ship> shipList);
    }
}