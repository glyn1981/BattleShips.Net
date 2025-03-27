using BattleShips.Helpers;

namespace BattleShips.Objects
{
    /// <summary>
    /// Initialises the ships
    /// </summary>
    class ShipInitialiser : IShipInitialiser
    {
        /// <summary>
        /// Initializes new random ships
        /// </summary>
        /// <param name="ships">a list of ships</param>
        /// <param name="board">the game board object</param>
        public void InitShips(List<Ship> ships, char[,] board,Random random, IUtils utils)
        {
            ///create new ships
            ships.Add(new Ship(5, "Battleship", "C"));
            ships.Add(new Ship(4, "Destroyer", "B"));
            ships.Add(new Ship(4, "Destroyer", "B"));

            //for each ship, place it on the board
            ShipPlacer shipPlacer = new ShipPlacer();
            for (int i = 0; i < ships.Count; i++)
            {
                shipPlacer.AddShipToBoard(ships[i], board,random, utils);
            }

        }


    }
}
