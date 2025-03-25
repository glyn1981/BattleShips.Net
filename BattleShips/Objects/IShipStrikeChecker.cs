
namespace BattleShips.Objects
{
    public interface IShipStrikeChecker
    {
        bool IsHit(string guess, List<Ship> ships);
    }
}