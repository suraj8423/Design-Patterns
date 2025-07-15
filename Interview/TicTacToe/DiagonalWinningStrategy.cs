namespace Interview.TictacToe;
public class DiagonalWinningStrategy : IWinningStrategy
{
    public bool CheckWinner(Board board, Symbol symbol)
    {
        bool win = true;
        for (int i = 0; i < board.Size; i++)
        {
            if (board.GetSymbol(i, i) != symbol)
            {
                win = false;
                break;
            }
        }
        if (win) return true;

        win = true;
        for (int i = 0; i < board.Size; i++)
        {
            if (board.GetSymbol(i, board.Size - 1 - i) != symbol)
            {
                win = false;
                break;
            }
        }
        return win;
    }
}