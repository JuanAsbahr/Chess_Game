﻿using Chess_Game;
using Chess_Game.ChessBoard;
using Chess_Game.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            ChessGame game = new ChessGame();

            while (!game.finished)
            {
                try
                {
                    Console.Clear();
                    Screen.printGame(game);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readPosition().toPosition();
                    game.validateOriginPosition(origin);

                    bool[,] possiblePositions = game.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.printBoard(game.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.readPosition().toPosition();
                    game.validateDetinationPosition(origin, destination);

                    game.performMove(origin, destination);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Screen.printGame(game);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}