namespace Interview.TictacToe;

public class Cell
{
    public Symbol Symbol { get; private set; }
    public Cell()
    {
        Symbol = Symbol.EMPTY;
    }
  public bool IsEmpty() => Symbol == Symbol.EMPTY;
    public void SetSymbol(Symbol symbol)
    {
        Symbol = symbol;
    }

}