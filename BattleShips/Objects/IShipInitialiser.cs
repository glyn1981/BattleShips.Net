
using BattleShips.Helpers;

namespace BattleShips.Objects
{
    /// <summary>
    /// Handles ship initialisation.
    /// </summary>
    public interface IShipInitialiser
    {
        void InitShips(List<Ship> ships, char[,] board, Random random, IUtils utils);
    }
}