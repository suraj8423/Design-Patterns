namespace Interview.TictacToe;
public class Program
{
    public static void Main()
    {
        var players = new List<Player>
        {
            new Player("Alice", Symbol.X),
            new Player("Bob", Symbol.O)
            // You can easily add more players with new symbols
        };

        var strategies = new List<IWinningStrategy>
        {
            new RowWinningStrategy(),
            new ColumnWinningStrategy(),
            new DiagonalWinningStrategy()
        };

        Console.WriteLine("Enter board size (n):");
        int size = int.Parse(Console.ReadLine());

        var game = new TicTacToeGame(players, size, strategies);
        game.Start();
    }
}
