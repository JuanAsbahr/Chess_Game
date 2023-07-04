using Chess_Game;
using Chess_Game.ChessBoard;
using Chess_Game.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        ChessPosition position = new ChessPosition('a', 1);
        Console.WriteLine(position);

        Console.WriteLine(position.toPosition());
    }
}