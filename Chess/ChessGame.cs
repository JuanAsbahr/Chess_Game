﻿using Chess_Game.ChessBoard;
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
        public Piece enPassantvulnerable { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            round = 1;
            currrentPlayer = Color.White;
            enPassantvulnerable = null;
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

            // # Special Move -> Kingside castling
            if (piece is King && destination.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestination = new Position(origin.line, origin.column + 1);
                Piece rook = board.removePiece(rookOrigin);
                rook.addMoves();
                board.insertPiece(rook, rookDestination);
            }
            // # Special Move -> Queenside castling
            if (piece is King && destination.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestination = new Position(origin.line, origin.column - 1);
                Piece rook = board.removePiece(rookOrigin);
                rook.addMoves();
                board.insertPiece(rook, rookDestination);
            }

            // # Special Move -> En Passant
            if (piece is Pawn)
            {
                if (origin.column != destination.column && caputuredPiece == null)
                {
                    Position posP;
                    if (piece.color == Color.White)
                    {
                        posP = new Position(destination.line + 1, destination.column);
                    }
                    else
                    {
                        posP = new Position(destination.line - 1, destination.column);
                    }
                    caputuredPiece = board.removePiece(posP);
                    captured.Add(caputuredPiece);
                }
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

            // # Special Move -> Kingside castling
            if (piece is King && destination.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestination = new Position(origin.line, origin.column + 1);
                Piece rook = board.removePiece(rookDestination);
                rook.removeMoves();
                board.insertPiece(rook, rookOrigin);
            }
            // # Special Move -> Queenside castling
            if (piece is King && destination.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestination = new Position(origin.line, origin.column - 1);
                Piece rook = board.removePiece(rookDestination);
                rook.removeMoves();
                board.insertPiece(rook, rookOrigin);
            }
            // # Special Move -> En Passant
            if (piece is Pawn)
            {
                if (origin.column != destination.column && capuredPiece == enPassantvulnerable)
                {
                    Piece pawn = board.removePiece(destination);
                    Position posP;
                    if (piece.color == Color.White)
                    {
                        posP = new Position(3, destination.column);
                    }
                    else
                    {
                        posP = new Position(4, destination.column);
                    }
                    board.insertPiece(pawn, posP);
                }
            }

        }

        public void performMove(Position origin, Position destination)
        {
            Piece capturedPiece = executeMovement(origin, destination);

            if (isInCheck(currrentPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }
            Piece p = board.piece(destination);

            // # Special Move -> Pawn Promove
            if (p is Pawn)
            {
                if ((p.color == Color.White && destination.line == 0) || (p.color == Color.Black && destination.line == 7))
                {
                    p = board.removePiece(destination);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color);
                    board.insertPiece(queen, destination);
                    pieces.Add(queen);
                }
            }

            if (isInCheck(opponent(currrentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (checkMate(opponent(currrentPlayer)))
            {
                finished = true;
            }
            else
            {
                round++;
                changePlayer();
            }


            // # Special Move -> En Passant
            if (p is Pawn && (destination.line == origin.line - 2 || destination.line == origin.line - 2))
            {
                enPassantvulnerable = p;
            }
            else
            {
                enPassantvulnerable = null;
            }

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
            if (currrentPlayer == Color.White)
            {
                currrentPlayer = Color.Black;
            }
            else
            {
                currrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPiece(Color color)
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
                bool[,] mat = x.possibleMoves();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in inGame(color))
            {
                bool[,] mat = x.possibleMoves();
                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, destination);
                            bool checkTest = isInCheck(color);
                            undoMove(origin, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void insertNewPiece(char column, int line, Piece piece)
        {
            board.insertPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {

            insertNewPiece('a', 1, new Rook(board, Color.White));
            insertNewPiece('h', 1, new Rook(board, Color.White));
            insertNewPiece('e', 1, new King(board, Color.White, this));
            insertNewPiece('d', 1, new Queen(board, Color.White));
            insertNewPiece('c', 1, new Bishop(board, Color.White));
            insertNewPiece('f', 1, new Bishop(board, Color.White));
            insertNewPiece('b', 1, new Horse(board, Color.White));
            insertNewPiece('g', 1, new Horse(board, Color.White));
            insertNewPiece('a', 2, new Pawn(board, Color.White, this));
            insertNewPiece('b', 2, new Pawn(board, Color.White, this));
            insertNewPiece('c', 2, new Pawn(board, Color.White, this));
            insertNewPiece('d', 2, new Pawn(board, Color.White, this));
            insertNewPiece('e', 2, new Pawn(board, Color.White, this));
            insertNewPiece('f', 2, new Pawn(board, Color.White, this));
            insertNewPiece('g', 2, new Pawn(board, Color.White, this));
            insertNewPiece('h', 2, new Pawn(board, Color.White, this));


            insertNewPiece('a', 8, new Rook(board, Color.Black));
            insertNewPiece('h', 8, new Rook(board, Color.Black));
            insertNewPiece('e', 8, new King(board, Color.Black, this));
            insertNewPiece('d', 8, new Queen(board, Color.Black));
            insertNewPiece('c', 8, new Bishop(board, Color.Black));
            insertNewPiece('f', 8, new Bishop(board, Color.Black));
            insertNewPiece('b', 8, new Horse(board, Color.Black));
            insertNewPiece('g', 8, new Horse(board, Color.Black));
            insertNewPiece('a', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('b', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('c', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('d', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('e', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('f', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('g', 7, new Pawn(board, Color.Black, this));
            insertNewPiece('h', 7, new Pawn(board, Color.Black, this));
        }
    }
}
