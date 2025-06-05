namespace BattleShips.Objects
{
    class GameUserInterface : IUserInterface
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine() ?? string.Empty;
        }

       public void Clear()
        {
            Console.Clear();
        }

    }
}
