namespace Interview.TictacToe;
public class ColumnWinningStrategy : IWinningStrategy
{
    public bool CheckWinner(Board board, Symbol symbol)
    {
        for (int j = 0; j < board.Size; j++)
        {
            bool win = true;
            for (int i = 0; i < board.Size; i++)
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