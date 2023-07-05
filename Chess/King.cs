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
            if(board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //North East
            position.setValues(position.Line - 1, position.Column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //East
            position.setValues(position.Line, position.Column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //Southeast
            position.setValues(position.Line + 1, position.Column + 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //South
            position.setValues(position.Line + 1, position.Column);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //South-West
            position.setValues(position.Line + 1, position.Column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //West
            position.setValues(position.Line, position.Column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            //Northwest
            position.setValues(position.Line - 1, position.Column - 1);
            if (board.validPosition(position) && canMove(position))
            {
                matrix[position.Line, position.Column] = true;
            }
            return matrix;
        }
    }
}
