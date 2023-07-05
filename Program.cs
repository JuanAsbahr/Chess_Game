using Chess_Game;
using Chess_Game.ChessBoard;
using Chess_Game.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ChessGame game = new ChessGame();

            Screen.printBoard(game.board);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}