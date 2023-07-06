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

        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);


            //North
            pos.setValues(position.line - 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }
            //South
            pos.setValues(position.line + 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            //East
            pos.setValues(position.line, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }
            //West
            pos.setValues(position.line, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            return matrix;
        }
    }
}
