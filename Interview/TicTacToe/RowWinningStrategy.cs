namespace Interview.TictacToe;
public class RowWinningStrategy : IWinningStrategy
{
    public bool CheckWinner(Board board, Symbol symbol)
    {
        for (int i = 0; i < board.Size; i++)
        {
            bool win = true;
            for (int j = 0; j < board.Size; j++)
            {
                if (board.GetSymbol(i, j) != symbol)
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;
        }
        return false;
    }
}