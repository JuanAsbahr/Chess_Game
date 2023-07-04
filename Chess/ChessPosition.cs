using Chess_Game.ChessBoard;

namespace Chess_Game.Chess
{
    internal class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }   

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public override string ToString()
        {
            return "" + column + line;
        }

        public Position toPosition()
        {
            return new Position(8 - line, column - 'a');
        }
    }
}
