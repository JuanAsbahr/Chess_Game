using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
