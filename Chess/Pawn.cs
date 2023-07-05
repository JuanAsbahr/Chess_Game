using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }
}