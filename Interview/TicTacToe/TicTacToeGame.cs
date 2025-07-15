namespace Interview.TictacToe;

public class TicTacToeGame
{
   private readonly List<IWinningStrategy> winningStrategies;
    private readonly List<Player> players;
    private readonly Board board;
    private int currentPlayerIndex;
    private GameStatus status;

    public TicTacToeGame(List<Player> players, int size, List<IWinningStrategy> strategies)
    {
        this.players = players;
        winningStrategies = strategies;
        board = new Board(size);
        currentPlayerIndex = 0;
        status = GameStatus.IN_PROGRESS;
    }
    
     public void Start()
    {
        board.Print();
        while (status == GameStatus.IN_PROGRESS)
        {
            var currentPlayer = players[currentPlayerIndex];
            Console.WriteLine($"{currentPlayer.Name} ({currentPlayer.Symbol}), enter your move as `row col`:");
            var input = Console.ReadLine().Split();
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            if (!board.IsValidMove(row, col))
            {
                Console.WriteLine("Invalid move. Try again.");
                continue;
            }

            board.PlaceMove(row, col, currentPlayer.Symbol);
            board.Print();

            if (winningStrategies.Any(s => s.CheckWinner(board, currentPlayer.Symbol)))
            {
                Console.WriteLine($"{currentPlayer.Name} wins!");
                status = GameStatus.WIN;
            }
            else if (board.IsFull())
            {
                Console.WriteLine("It's a draw!");
                status = GameStatus.DRAW;
            }
            else
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
        }
    }
}