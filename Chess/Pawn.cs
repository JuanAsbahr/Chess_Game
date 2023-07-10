using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class Pawn : Piece
    {
        private ChessGame game;
        public Pawn(Board board, Color color, ChessGame game) : base(color, board)
        {
            this.game = game;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool opponent(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool empty(Position pos)
        {
            return board.piece(pos) == null;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.line - 1, position.column);
                if (board.validPosition(pos) && empty(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 2, position.column);
                Position position1 = new Position(position.line - 1, position.column);
                if (board.validPosition(position1) && empty(position1) && board.validPosition(pos) && empty(pos) && moves == 0)
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column - 1);
                if (board.validPosition(pos) && opponent(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column + 1);
                if (board.validPosition(pos) && opponent(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.line + 1, position.column);
                if (board.validPosition(pos) && empty(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 2, position.column);
                Position position1 = new Position(position.line + 1, position.column);
                if (board.validPosition(position1) && empty(position1) && board.validPosition(pos) && empty(pos) && moves == 0)
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column - 1);
                if (board.validPosition(pos) && opponent(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column + 1);
                if (board.validPosition(pos) && opponent(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
            }
            return matrix;
        }
    }
}