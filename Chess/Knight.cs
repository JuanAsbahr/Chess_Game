using System;
using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "Kn";
        }
    }
}
