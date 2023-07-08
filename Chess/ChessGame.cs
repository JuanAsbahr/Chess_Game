using Chess_Game.ChessBoard;
using System.Collections.Generic;

namespace Chess_Game.Chess
{
    internal class ChessGame
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color currrentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessGame()
        {
            board = new Board(8,8);
            round = 1;
            currrentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces(); 
        }

        public Piece executeMovement(Position origin, Position destination)
        {
            Piece piece = board.removePiece(origin);
            piece.addMoves();
            Piece caputuredPiece = board.removePiece(destination);
            board.insertPiece(piece, destination);
            if (caputuredPiece != null)
            {
                captured.Add(caputuredPiece);
            }
            return caputuredPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capuredPiece)
        {
            Piece piece = board.removePiece(destination);
            piece.removeMoves();
            if (capuredPiece != null)
            {
                board.insertPiece(capuredPiece, destination);
                captured.Remove(capuredPiece);
            }
            board.insertPiece(piece, origin);
        }

        public void performMove(Position origin, Position destination)
        {
            Piece capturedPiece = executeMovement(origin, destination);

            if (isInCheck(currrentPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }
            if (isInCheck(opponent(currrentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            round++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("No piece in chosen origin position!");
            }
            if (currrentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The piece chosen is not yours!");
            }
            if (!board.piece(pos).hasPossibleMoves())
            {
                throw new BoardException("No moves possible!");
            }
        }

        public void validateDetinationPosition(Position origin, Position destination)
        {
            if (!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
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

        public HashSet<Piece> capturedPiece (Color color)
        {
            HashSet<Piece> result = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    result.Add(x);
                }
            }
            return result;
        }

        public HashSet<Piece> inGame(Color color)
        {
            HashSet<Piece> result = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    result.Add(x);     
                }
            }
            result.ExceptWith(capturedPiece(color));
            return result;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in inGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no king on the game!");
            }
            foreach (Piece x in inGame(opponent(color)))
            {
                bool[,] matrix = x.possibleMoves();
                if (matrix[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public void insertNewPiece(char column, int line, Piece piece)
        {
            board.insertPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            insertNewPiece('a',1, new Rook(board,Color.White));
            insertNewPiece('h', 1, new Rook(board, Color.White));
            insertNewPiece('d', 1, new King(board, Color.White));

            insertNewPiece('a', 8, new Rook(board, Color.Black));
            insertNewPiece('h', 8, new Rook(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
