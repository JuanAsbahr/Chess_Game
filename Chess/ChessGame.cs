using Chess_Game.ChessBoard;
using System;

namespace Chess_Game.Chess
{
    internal class ChessGame
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color currrentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8,8);
            round = 1;
            currrentPlayer = Color.White;
            putPieces(); 
            finished = false;
        }

        public void executeMovement(Position origin, Position destination)
        {
            Piece piece = board.removePiece(origin);
            piece.addMoves();
            Piece caputuredPiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
        }

        public void performMove(Position origin, Position destination)
        {
            executeMovement(origin, destination);
            round++;
            changePlayer();
        }

        private void changePlayer()
        {
            if(currrentPlayer == Color.White)
            {
                currrentPlayer = Color.Black;
            }
            else
            {
                currrentPlayer = Color.White;
            }
        }

        private void putPieces()
        {
            board.insertPiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.insertPiece(new Rook(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.insertPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());
;



            board.insertPiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.insertPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.insertPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
