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

        public Piece piece (Position position)
        {
            return pieces[position.line, position.column];
        }

        public bool thereIsPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void insertPiece (Piece piece, Position pos)
        {
            if(thereIsPiece(pos))
            {
                throw new BoardException("There is a piece in this position!");
            }
            pieces[pos.line, pos.column] = piece;
            piece.position = pos;
        }

        public Piece removePiece(Position position)
        {
            if (piece(position) == null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.position = null;
            pieces[position.line, position.column] = null;
            return aux;
        }

        public bool validPosition(Position pos)
        {
            if (pos.line<0 || pos.line>=lines || pos.column <0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
