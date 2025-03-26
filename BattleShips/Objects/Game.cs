namespace BattleShips.Objects
{
    /// <summary>
    /// Class that encompasses the game of battleships.
    /// </summary>
    public class Game : IGame
    {
        private const int BOARD_SIZE = 10;
        private readonly char[,] board;
        private readonly List<Ship> ships;
        private readonly List<string> guesses;
        private readonly Random random;

        /// <summary>
        /// DI Constructor
        /// </summary>
        /// <param name="Ships">The collection of ships</param>
        /// <param name="Guesses">A collection of guesses</param>
        /// <param name="randomiser">The Random object</param>
        public Game(List<Ship> Ships, List<string> Guesses, Random randomiser)
        {
            board = new char[BOARD_SIZE + 1, BOARD_SIZE + 1];
            ships = Ships;
            guesses = Guesses;
            random = randomiser;
        }

        /// <summary>
        /// Starts a new game of Battleships
        /// </summary>
        public void Start()
        {
            //inisitalise the board and ships

            BoardInitialiser boardInitialiser = new BoardInitialiser();
            boardInitialiser.InitBoard(BOARD_SIZE, board);

            //if there were no ships DI'd in then create them.
            //added to support unit testing.
            if (ships.Count == 0)
            {
                ShipInitialiser shipInitialiser = new ShipInitialiser();
                shipInitialiser.InitShips(ships, board);
            }

            //display the board.
            GameDisplay gameDisplay = new GameDisplay();
            gameDisplay.DisplayBoard(ships, BOARD_SIZE, board);

            //get the users guess
            InputHandler inputHandler = new InputHandler();
            inputHandler.GetGuess(guesses, ships, board);

        }
        /// <summary>
        /// Handles the players next turn including updating the ui and collecting input from the user.
        /// </summary>
        public void NextTurn()
        {
            //display the board.
            GameDisplay gameDisplay = new GameDisplay();
            gameDisplay.DisplayBoard(ships, BOARD_SIZE, board);

            //get the users guess
            InputHandler inputHandler = new InputHandler();
            inputHandler.GetGuess(guesses, ships, board);
        }

        /// <summary>
        /// Checks if the game is over
        /// </summary>
        public bool CheckGameOver()
        {
            //if all the ships are sunk then the game is over.
            return ships.All(ship => ship.IsSunk);
        }

    }
}