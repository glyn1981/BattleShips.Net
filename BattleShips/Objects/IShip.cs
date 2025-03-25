namespace BattleShips.Objects
{
    public interface IShip
    {
        int Hits { get; set; }
        string Name { get; set; }
        List<string> Positions { get; set; }
        int Size { get; set; }
        string Symbol { get; set; }

        void Hit();
        bool IsHit(string guess);
    }
}