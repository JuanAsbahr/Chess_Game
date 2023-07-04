namespace Chess_Game.ChessBoard
{
    internal class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int moves { get; protected set; }
        public Board board { get; protected set; }

        public Piece (Position position, Color color, Board board)
        {
            this.position = position;
            this.color = color;
            this.moves = 0;
            this.board = board;
        }
    }
}
