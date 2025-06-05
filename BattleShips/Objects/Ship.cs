namespace BattleShips.Objects
{
    /// <summary>
    /// The ship class
    /// </summary>
    public class Ship : IShip
    {
        public int Size { get; set; }
        public int Hits { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public List<string> Positions { get; set; }

        public bool IsSunk;

    /// <summary>
    /// Constructor for a new ship object.
    /// </summary>
    /// <param name="size">how many sqares in size is the ship</param>
    /// <param name="name">give the ship a name, i.e hms disaster.</param>
    /// <param name="symbol">the symbol for the ship :Note not actually used.</param>
        public Ship(int size, string name, string symbol)
        {
            Size = size;
            Hits = 0;
            Name = name;
            Symbol = symbol;
            IsSunk = false;
            Positions = new List<string>();

        }


        /// <summary>
        /// the ship has taken a hit - shiver me timbers.
        /// </summary>
        public void Hit()
        {
            Hits++;
            // if the number of hits is equal to the size of the ship then it is sunk.
            if (Hits == Size)
            {
                IsSunk = true;
            }
        }

        /// <summary>
        /// checks whether the ship has taken a direct hit.
        /// </summary>
        /// <param name="guess">the guess i.e A1</param>
        /// <returns></returns>
        public bool IsHit(string guess)
        {

            // if the guess is in the list of positions then it is a hit.   
            if (Positions.Contains(guess))
            {
                Hit();
                return true;
            }

            return false;
        }

    }

}
