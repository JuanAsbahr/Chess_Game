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
            return pieces[position.Line, position.Column];
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
            pieces[position.Line, position.Column] = piece;
            piece.position = position;
        }

        public bool validPosition(Position position)
        {
            if (position.Line<0 || position.Line>=lines || position.Column <0 || position.Column >= columns)
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
