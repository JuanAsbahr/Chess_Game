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
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column);
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
                pos.setValues(pos.line + 1, pos.column);
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
                pos.setValues(pos.line, pos.column + 1);
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
                pos.setValues(pos.line, pos.column - 1);
            }
            //Northwest
            pos.setValues(position.line - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column - 1);
            }
            //North East 
            pos.setValues(position.line - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column + 1);
            }
            //Southeast
            pos.setValues(position.line + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column + 1);
            }
            //South-West
            pos.setValues(position.line + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                matrix[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column - 1);
            }

            return matrix;
        }
    }
}