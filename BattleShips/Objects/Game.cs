namespace BattleShips.Objects
{
    public class Game : IGame
    {
        private const int BOARD_SIZE = 10;
        private readonly char[,] board;
        private readonly List<Ship> ships;
        private readonly List<string> guesses;
        private readonly Random random;

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
            return ships.All(ship => ship.IsSunk);
        }

    }
}