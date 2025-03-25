
using BattleShips.Objects;

namespace BattleShips
{
    class BattleShipsGame
    {

        static void Main()
        {

            GameDisplay gameDisplay = new GameDisplay();    

            // create a new game
            Game game = new Game(new List<Ship>(), new List<string>(), new Random());
            // start the game
            game.Start();

            while (game.CheckGameOver() == false)
            {
                game.NextTurn();
            }

            //the game is over, you won !.
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Restart to play again.");
            Thread.Sleep(5000);
                
        }

    }
}