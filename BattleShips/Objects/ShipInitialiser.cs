namespace BattleShips.Objects
{
    class ShipInitialiser : IShipInitialiser
    {
        /// <summary>
        /// Initializes new random ships
        /// </summary>
        public void InitShips(List<Ship> ships, char[,] board)
        {
            ships.Add(new Ship(5, "Battleship", "C"));
            ships.Add(new Ship(4, "Destroyer", "B"));
            ships.Add(new Ship(4, "Destroyer", "B"));
            ShipPlacer shipPlacer = new ShipPlacer();
            for (int i = 0; i < ships.Count; i++)
            {
                shipPlacer.AddShipToBoard(ships[i], board);
            }

        }


    }
}
