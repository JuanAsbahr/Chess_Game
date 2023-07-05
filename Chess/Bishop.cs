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

        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position position = new Position(0, 0);

            //Northwest
            position.setValues(position.Line - 1, position.Column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line - 1, position.Column -1);
            }
            //North East 
            position.setValues(position.Line - 1, position.Column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line - 1, position.Column + 1);
            }
            //Southeast
            position.setValues(position.Line + 1, position.Column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line + 1, position.Column + 1);
            }
            //South-West
            position.setValues(position.Line + 1, position.Column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line + 1, position.Column - 1);
            }

            return matrix;
        }
    }
}
