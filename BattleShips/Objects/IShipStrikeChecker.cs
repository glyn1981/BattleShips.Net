
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the checking of whether a ship has been hit.
    /// </summary>
    public interface IShipStrikeChecker
    {
        bool IsHit(string guess, List<Ship> ships);
    }
}