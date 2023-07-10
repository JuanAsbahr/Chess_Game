using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class King : Piece
    {
        private ChessGame game;
        public King(Board board, Color color, ChessGame game) : base(color, board)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "K";
        }

        public bool rookCastlingTest(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.moves == 0;
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
            if (board.validPosition(pos) && canMove(pos))
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

            // # Special Move -> Kingside castling

            if (moves == 0 && !game.check)
            {
                Position posRook1 = new Position(position.line, position.column + 3);
                if (rookCastlingTest(posRook1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        matrix[position.line, position.column + 2] = true;
                    }
                }
                //# Special Move -> Queenside castling            
                Position posRook2 = new Position(position.line, position.column - 4);
                if (rookCastlingTest(posRook2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        matrix[position.line, position.column - 2] = true;
                    }
                }
            }
            return matrix;
        }
    }
}
