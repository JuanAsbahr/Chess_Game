using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
