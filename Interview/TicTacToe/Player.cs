namespace Interview.TictacToe;

public class Player
{
    public string Name { get; }
    public Symbol Symbol { get; }
    public Player(string name, Symbol symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}