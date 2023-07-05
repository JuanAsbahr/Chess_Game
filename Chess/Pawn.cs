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

        private bool opponent(Position position)
        {
            Piece piece = board.piece(position);
            return piece != null && piece.color != color;
        }

        private bool empty(Position position)
        {
            return board.piece(position) == null;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position position = new Position(0, 0);

            if (color == Color.White)
            {
                position.setValues(position.Line - 1, position.Column);
                if (board.validPosition(position) && empty(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line - 2, position.Column);
                if (board.validPosition(position) && empty(position) && moves == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line - 1, position.Column - 1);
                if (board.validPosition(position) && opponent(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line - 1, position.Column + 1);
                if (board.validPosition(position) && opponent(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.setValues(position.Line + 1, position.Column);
                if (board.validPosition(position) && empty(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line + 2, position.Column);
                if (board.validPosition(position) && empty(position) && moves == 0)
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line + 1, position.Column - 1);
                if (board.validPosition(position) && opponent(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
                position.setValues(position.Line + 1, position.Column + 1);
                if (board.validPosition(position) && opponent(position))
                {
                    matrix[position.Line, position.Column] = true;
                }
            }
            return matrix;
        }
    }
}