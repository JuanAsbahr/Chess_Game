namespace Chess_Game.ChessBoard
{
    internal class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines,columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece (Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool thereIsPiece(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public void insertPiece (Piece piece, Position position)
        {
            if(thereIsPiece(position))
            {
                throw new BoardException("There is a piece in this position!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public Piece removePiece(Position position)
        {
            if (piece(position) == null)
            {
                return null;
            }
            Piece pos = piece(position);
            pos.position = null;
            pieces[position.line, position.column] = null;
            return pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.line<0 || pos.line>=lines || pos.column <0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
