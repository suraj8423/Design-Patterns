namespace Interview.TictacToe;

public class Board
{
    private readonly Cell[,] grid;
    private int movesCount;
    public int Size { get; }
    public Board(int size)
    {
        Size = size;
        grid = new Cell[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                grid[i, j] = new Cell();
    }

    public bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < Size && col >= 0 && col < Size && grid[row, col].IsEmpty();
    }
    public void PlaceMove(int row, int col, Symbol symbol)
    {
        grid[row, col].SetSymbol(symbol);
        movesCount++;
    }
    public bool IsFull() => movesCount == Size * Size;

    public Symbol GetSymbol(int row, int col) => grid[row, col].Symbol;
      
       public void Print()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write($"{grid[i, j].Symbol} ");
            }
            Console.WriteLine();
        }
    }
}