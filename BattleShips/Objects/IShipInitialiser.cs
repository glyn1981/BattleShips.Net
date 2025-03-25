
namespace BattleShips.Objects
{
    internal interface IShipInitialiser
    {
        void InitShips(List<Ship> ships, char[,] board);
    }
}