namespace BattleShips.Objects
{
    public class Ship : IShip
    {
        public int Size { get; set; }
        public int Hits { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public List<string> Positions { get; set; }

        public bool IsSunk;

        // Constructor for the ship
        public Ship(int size, string name, string symbol)
        {
            Size = size;
            Hits = 0;
            Name = name;
            Symbol = symbol;
            IsSunk = false;
            Positions = new List<string>();

        }


        //the ship has taken a hit - shiver me timbers.
        public void Hit()
        {
            Hits++;
            if (Hits == Size)
            {
                IsSunk = true;
            }
        }

        //has the ship been hit?
        public bool IsHit(string guess)
        {

            if (Positions.Contains(guess))
            {
                Hit();
                return true;
            }
            return false;
        }

    }

}
