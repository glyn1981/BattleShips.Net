using BattleShips.Helpers;

namespace BattleShips.Objects
{
    /// <summary>
    /// Class that encompasses the game of battleships.
    /// </summary>
    public class Game : IGame
    {
        private const int BOARD_SIZE = 10;
        private readonly char[,] board;
        private readonly List<Ship> _ships;
        private readonly List<string> _guesses;
        private readonly Random _random;
        private IInputValidator _inputValidator;
        private IInputHandler _inputHandler;
        private IUtils _utils;
        private IShipStrikeChecker _shipStrikeChecker;

        /// <summary>
        /// DI Constructor
        /// </summary>
        /// <param name="Ships">The collection of ships</param>
        /// <param name="Guesses">A collection of guesses</param>
        /// <param name="randomiser">The Random object</param>
        public Game(List<Ship> Ships, List<string> Guesses, Random randomiser, IInputValidator inputValidator, IUtils utils, IInputHandler inputHandler, IShipStrikeChecker shipStrikeChecker)
        {
            board = new char[BOARD_SIZE + 1, BOARD_SIZE + 1];
            _ships = Ships;
            _guesses = Guesses;
            _random = randomiser;
            _inputValidator = inputValidator;
            _utils = utils;
            _inputHandler = inputHandler;
            _shipStrikeChecker = shipStrikeChecker;
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
            if (_ships.Count == 0)
            {
                ShipInitialiser shipInitialiser = new ShipInitialiser();
                shipInitialiser.InitShips(_ships, board,_random, _utils);
            }

            NextTurn();

        }
        /// <summary>
        /// Handles the players next turn including updating the ui and collecting input from the user.
        /// </summary>
        public void NextTurn()
        {
            //display the board.
            GameDisplay gameDisplay = new GameDisplay();
            gameDisplay.DisplayBoard(_ships, BOARD_SIZE, board);

            //get the users guess
            _inputHandler.GetGuess(_guesses, _ships, board, _utils,_inputValidator, _shipStrikeChecker);
        }

        /// <summary>
        /// Checks if the game is over
        /// </summary>
        public bool CheckGameOver()
        {
            //if all the ships are sunk then the game is over.
            return _ships.All(ship => ship.IsSunk);
        }

    }
}