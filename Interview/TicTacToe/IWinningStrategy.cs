namespace Interview.TictacToe;

public interface IWinningStrategy
{
    bool CheckWinner(Board board, Symbol symbol);
}
