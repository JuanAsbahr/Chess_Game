namespace Chess_Game.ChessBoard
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int moves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board)
        {
            this.position = null;
            this.color = color;
            this.moves = 0;
            this.board = board;
        }

        public void addMoves()
        {
            moves++;
        }

        public bool hasPossibleMoves()
        {
            bool[,] matrix = possibleMoves();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] possibleMoves();
    }
}
