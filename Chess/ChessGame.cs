using Chess_Game.ChessBoard;
using System;
using System.Security.AccessControl;

namespace Chess_Game.Chess
{
    internal class ChessGame
    {
        public Board board { get; private set; }
        private int round;
        private Color currrentPlayer;

        public ChessGame()
        {
            board = new Board(8,8);
            round = 1;
            currrentPlayer = Color.White;
            putPieces(); 
        }

        public void executeMovement(Position origin, Position destination)
        {
            Piece piece = board.removePiece(origin);
            piece.addMoves();
            Piece caputuredPiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
        }

        private void putPieces()
        {
            board.insertPiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.insertPiece(new Rook(board, Color.White), new ChessPosition('h', 1).toPosition());
            board.insertPiece(new Horse(board, Color.White), new ChessPosition('b', 1).toPosition());
            board.insertPiece(new Horse(board, Color.White), new ChessPosition('g', 1).toPosition());
            board.insertPiece(new Bishop(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.insertPiece(new Bishop(board, Color.White), new ChessPosition('f', 1).toPosition());
            board.insertPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());
            board.insertPiece(new Queen(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('a', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('b', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('f', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('g', 2).toPosition());
            board.insertPiece(new Pawn(board, Color.White), new ChessPosition('h', 2).toPosition());



            board.insertPiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.insertPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.insertPiece(new Horse(board, Color.Black), new ChessPosition('b', 8).toPosition());
            board.insertPiece(new Horse(board, Color.Black), new ChessPosition('g', 8).toPosition());
            board.insertPiece(new Bishop(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.insertPiece(new Bishop(board, Color.Black), new ChessPosition('f', 8).toPosition());
            board.insertPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
            board.insertPiece(new Queen(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('a', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('b', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('f', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('g', 7).toPosition());
            board.insertPiece(new Pawn(board, Color.Black), new ChessPosition('h', 7).toPosition());
        }
    }
}
