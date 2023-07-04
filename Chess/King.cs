using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class King : Piece
    {
        public King (Board board, Color color): base(color,board)
        {
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
