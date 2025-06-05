namespace BattleShips.Objects
{
   public interface IUserInterface
    {
        void Clear();
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
    }
}
