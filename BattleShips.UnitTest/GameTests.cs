using BattleShips.Objects;
using System.Numerics;

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

            Assert.False(inputValidator.AlreadyGuessed("A1", ["B1","C1","D1" ]));
            Assert.True(inputValidator.AlreadyGuessed("A1", ["A1", "C1", "D1"]));
        }

        [Fact]
        public void TestHitChecking()
        {
            Objects.Ship ship = new Objects.Ship(3, "Test Ship", "T");

            ship.Positions.Add("C1");
            ship.Positions.Add("C2");
            ship.Positions.Add("C3");

            Assert.False(ship.IsHit(new List<string> { "A1", "B1", "D1" }));
            Assert.True(ship.IsHit(new List<string> { "A1", "B1", "C1" }));
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

            //go theough each guess and check if it is a hit
            foreach (string guess in guesses)
            {
                //check each ship to see if it is a hit
                foreach ( Ship thisShip in shipList)
                {
                    thisShip.IsHit(guesses);
                }
            }


            Game gameObject = new Game(shipList, new List<string>(), new Random());

            Assert.True(gameObject.CheckGameOver());



        }




    }
}