using BattleShips.Helpers;
using BattleShips.Objects;

namespace BattleShips.UnitTest
{
    public class GameTests
    {
        /// <summary>
        /// Tests that the input validation works as expected.
        /// </summary>
        [Fact]
        public void TestInputValidation()
        {
            Helpers.InputValidator inputValidator = new Helpers.InputValidator();

            Assert.True(inputValidator.IsValidA1Format("A1"));
            Assert.False(inputValidator.IsValidA1Format("Z1"));
            Assert.False(inputValidator.IsValidA1Format("A11"));
        }

        /// <summary>
        /// Tests that the function to determine whether a guess has already been made works as expected.
        /// </summary>
        [Fact]
        public void TestAlreadyGuessedFunction()
        {
            Helpers.InputValidator inputValidator = new Helpers.InputValidator();

            Assert.False(inputValidator.AlreadyGuessed("A1", ["B1", "C1", "D1"]));
            Assert.True(inputValidator.AlreadyGuessed("A1", ["A1", "C1", "D1"]));
        }

        /// <summary>
        /// Test that the hit detection functionality works as expected.
        /// </summary>
        [Fact]
        public void TestHitChecking()
        {

            //create a ship with some positions
            Ship ship = new Ship(3, "Test Ship", "T");
            ship.Positions.Add("C1");
            ship.Positions.Add("C2");
            ship.Positions.Add("C3");

            //hit 3 squares where the ship is not.
            ship.IsHit("A1");
            ship.IsHit("B1");
            ship.IsHit("D1");
            //should not be sunk
            Assert.False(ship.IsSunk);

            //hit 3 squares where the ship is located.
            ship.IsHit("C1");
            ship.IsHit("C2");
            ship.IsHit("C3");
            //shiver me timbers, the ship should be on the ocean floor.
            Assert.True(ship.IsSunk);
        }

        /// <summary>
        /// Tests that ships sink when they are supposed to .
        /// </summary>
        [Fact]
        public void TestShipsSink()
        {
            //a ship that takes up 3 squares should take 3 hits to sink
            Ship ship = new Ship(3, "Test Ship", "T");
            ship.Hit();
            ship.Hit();
            ship.Hit();
            Assert.True(ship.IsSunk);

            //a ship that takes up 4 squares should not be sunk from 3 hits.
            Ship ship2 = new Ship(4, "Test Ship", "T");
            ship2.Hit();
            ship2.Hit();
            ship2.Hit();
            Assert.False(ship2.IsSunk);

            //a ship that takes up 4 squares should be sunk from 4 hits.
            Ship ship3 = new Ship(4, "Test Ship", "T");
            ship3.Hit();
            ship3.Hit();
            ship3.Hit();
            ship3.Hit();
            Assert.True(ship3.IsSunk);

        }


        /// <summary>
        /// Tests the game logic works as expected.
        /// </summary>
        [Fact]
        public void TestGameLogic()
        {
            List<Ship> shipList = new List<Ship>();
            //initialise some ships and guesses where all ships have been sunk
            Ship ship = new Ship(3, "Test Ship", "T");
            ship.Positions.Add("C1");
            ship.Positions.Add("D1");
            ship.Positions.Add("E1");
            Ship ship2 = new Ship(3, "Test Ship", "T");
            ship2.Positions.Add("C2");
            ship2.Positions.Add("D2");
            ship2.Positions.Add("E2");
            shipList.Add(ship);
            shipList.Add(ship2);
            List<string> guesses = ["C1", "D1", "E1", "C2", "D2", "E2"];

            foreach (string guess in guesses)
            {
                ship.IsHit(guess);
                ship2.IsHit(guess);
            }

            //since all ships have  been sunk the game should be over.
            Game gameObject = new Game(shipList, new List<string>(), new Random(), new InputValidator(), new Utils(),new InputHandler(), new ShipStrikeChecker());
            Assert.True(gameObject.CheckGameOver());
        }

        /// <summary>
        /// Tests the game logic works as expected.
        /// </summary>
        [Fact]
        public void TestGameLogic2()
        {
            //initialise some ships and guesses where not all ships have been sunk
            List<Ship> shipList = new List<Ship>();

            Ship ship = new Ship(3, "Test Ship", "T");
            ship.Positions.Add("C1");
            ship.Positions.Add("D1");
            ship.Positions.Add("E1");
            Ship ship2 = new Ship(4, "Test Ship", "T");
            ship2.Positions.Add("C2");
            ship2.Positions.Add("D2");
            ship2.Positions.Add("E2");
            ship2.Positions.Add("F2");
            List<string> guesses = ["C1", "D1", "E1", "C2", "D2", "E2"];

            foreach (string guess in guesses)
            {
                ship.IsHit(guess);
                ship2.IsHit(guess);
            }

            shipList.Add(ship);
            shipList.Add(ship2);

            //since all ships have not been sunk the game should not be over.
            Game gameObject = new Game(shipList, new List<string>(), new Random(), new InputValidator(), new Utils(), new InputHandler( ), new ShipStrikeChecker());
            Assert.False(gameObject.CheckGameOver());
        }


    }
}