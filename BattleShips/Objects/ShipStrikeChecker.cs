namespace BattleShips.Objects
{
    public class ShipStrikeChecker : IShipStrikeChecker
    {

        /// <summary>
        /// check if the ship has been struck.
        /// </summary>
        public bool IsHit(string guess, List<Ship> ships)
        {
            return ships.SelectMany(x => x.Positions).Contains(guess);
        }

    }
}
