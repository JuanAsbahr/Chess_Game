﻿using Chess_Game;
using Chess_Game.ChessBoard;

internal class Program
{
    private static void Main(string[] args)
    {
        Board board = new Board(8, 8);

        Screen.printBoard(board);
    }
}