namespace BattleShips.Objects
{
    /// <summary>
    /// Handles the checking of whether a ship has been hit.
    /// </summary>
    public class ShipStrikeChecker : IShipStrikeChecker
    {

        /// <summary>
        /// check if the ship has been struck.
        /// </summary>
        /// <param name="guess">the players guess i.e A1</param>
        /// <param name="ships">a list of the ships</param>
        /// <returns></returns>
        public bool IsHit(string guess, List<Ship> ships)
        {
            // if the guess is in the list of positions then it is a hit.
            return ships.SelectMany(x => x.Positions).Contains(guess);
        }

    }
}
