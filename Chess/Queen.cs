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

        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position position = new Position(0, 0);


            //North
            position.setValues(position.Line - 1, position.Column);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line - 1, position.Column);
            }
            //South
            position.setValues(position.Line + 1, position.Column);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line + 1, position.Column);
            }
            //East
            position.setValues(position.Line, position.Column + 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line, position.Column + 1);
            }
            //West
            position.setValues(position.Line, position.Column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line, position.Column - 1);
            }
            //Northwest
            position.setValues(position.Line - 1, position.Column - 1);
            while (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (board.piece(position) == null && board.piece(position).color != color)
                {
                    break;
                }
                position.setValues(position.Line - 1, position.Column - 1);
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