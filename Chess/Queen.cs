using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}