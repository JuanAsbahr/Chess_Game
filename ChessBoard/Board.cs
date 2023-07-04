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

        public void insertPiece (Piece piece, Position position)
        {
            pieces[position.Line, position.Column] = piece;
            piece.position = position;
        }
    }
}
