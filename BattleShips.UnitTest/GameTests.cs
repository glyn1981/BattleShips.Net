using BattleShips.Objects;

namespace BattleShips.UnitTest
{
    public class GameTests
    {
        [Fact]
        public void TestInputValidation()
        {
            Helpers.InputValidator inputValidator = new Helpers.InputValidator();

            Assert.True(inputValidator.IsValidA1Format("A1"));
            Assert.False(inputValidator.IsValidA1Format("Z1"));
            Assert.False(inputValidator.IsValidA1Format("A11"));
        }


        [Fact]
        public void TestAlreadyGuessedFunction()
        {
            Helpers.InputValidator inputValidator = new Helpers.InputValidator();

            Assert.False(inputValidator.AlreadyGuessed("A1", ["B1", "C1", "D1"]));
            Assert.True(inputValidator.AlreadyGuessed("A1", ["A1", "C1", "D1"]));
        }

        [Fact]
        public void TestHitChecking()
        {
            Objects.Ship ship = new Objects.Ship(3, "Test Ship", "T");

            ship.Positions.Add("C1");
            ship.Positions.Add("C2");
            ship.Positions.Add("C3");


            ship.IsHit("A1");
            ship.IsHit("B1");
            ship.IsHit("D1");
            Assert.False(ship.IsSunk);

            ship.IsHit("C1");
            ship.IsHit("C2");
            ship.IsHit("C3");

            Assert.True(ship.IsSunk);
        }


        [Fact]
        public void TestShipsSink()
        {
            Objects.Ship ship = new Objects.Ship(3, "Test Ship", "T");
            ship.Hit();
            ship.Hit();
            ship.Hit();
            Assert.True(ship.IsSunk);

        }

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

            Game gameObject = new Game(shipList, new List<string>(), new Random());
            Assert.True(gameObject.CheckGameOver());
        }

        [Fact]
        public void TestGameLogic2()
        {
            //initialise some ships and guesses where all ships have been sunk
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

            Game gameObject = new Game(shipList, new List<string>(), new Random());
            Assert.False(gameObject.CheckGameOver());
        }


    }
}