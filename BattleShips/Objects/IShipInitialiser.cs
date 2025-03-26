
namespace BattleShips.Objects
{
    /// <summary>
    /// Handles ship initialisation.
    /// </summary>
    internal interface IShipInitialiser
    {
        void InitShips(List<Ship> ships, char[,] board);
    }
}