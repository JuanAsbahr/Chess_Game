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

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //North
            pos.setValues(position.line - 1, position.column);
            if(board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //North East
            pos.setValues(position.line - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //East
            pos.setValues(position.line, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //Southeast
            pos.setValues(position.line + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //South
            pos.setValues(position.line + 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //South-West
            pos.setValues(position.line + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //West
            pos.setValues(position.line, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            //Northwest
            pos.setValues(position.line - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            return matrix;
        }
    }
}
