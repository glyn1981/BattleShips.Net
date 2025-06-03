namespace BattleShips.Objects
{
    class GameOverChecker : IGameOverChecker
    {

        public bool GameOver(List<Ship> shipList)
        {
            return shipList.All(ship => ship.IsSunk);
        }
    }
}
