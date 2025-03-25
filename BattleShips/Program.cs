
using BattleShips.Objects;

namespace BattleShips
{
    class BattleShipsGame
    {

        static void Main()
        {
            // create a new game
            Game game = new Game(new List<Ship>(), new List<string>(), new Random());
            // start the game
            game.Start();

            while (game.CheckGameOver() == false)
            {
                // update the output to show the current state of the game
                game.DisplayBoard();
                // get the user's guess
                game.GetGuess();

            }

            //the game is over, you won !.
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Restart to play again.");
        }

    }
}