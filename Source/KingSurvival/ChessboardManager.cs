﻿// ********************************
// <copyright file="ChessboardManager.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Used to process user commands and move the chess pieces on the chessboard.
    /// </summary>
    public class ChessboardManager
    {
        private const int ChessboardSize = 8;
        private const char KingCharacter = 'K';
        private const char WhiteSquareCharacter = '+';
        private const char BlackSquareCharacter = '-';

        private static readonly string[] Commands = { "KUL", "KUR", "KDL", "KDR", "ADL", "ADR", "BDL", "BDR", "CDL", "CDR", "DDL", "DDR" };
        private static readonly Dictionary<string, Move> ValidKingMoves;
        private static readonly Dictionary<string, Move> ValidPawnMoves;

        private Dictionary<char, ChessPiece> chessPieces;

        private bool[,] occupied;

        /// <summary>
        /// Initializes static members of the <see cref="ChessboardManager"/> class.
        /// </summary>
        static ChessboardManager()
        {
            ValidKingMoves = new Dictionary<string, Move>();
            ValidKingMoves["DL"] = new Move(1, -1);
            ValidKingMoves["DR"] = new Move(1, 1);
            ValidKingMoves["UL"] = new Move(-1, -1);
            ValidKingMoves["UR"] = new Move(-1, 1);

            ValidPawnMoves = new Dictionary<string, Move>();
            ValidPawnMoves["DL"] = new Move(1, -1);
            ValidPawnMoves["DR"] = new Move(1, 1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessboardManager"/> class.
        /// </summary>
        public ChessboardManager()
        {
            this.occupied = new bool[ChessboardSize, ChessboardSize];
            this.occupied[7, 3] = true;
            this.occupied[0, 0] = true;
            this.occupied[0, 2] = true;
            this.occupied[0, 4] = true;
            this.occupied[0, 6] = true;

            this.chessPieces = new Dictionary<char, ChessPiece>();
            this.chessPieces['K'] = new ChessPiece(ChessPieceType.King, 'K', 7, 3);
            this.chessPieces['A'] = new ChessPiece(ChessPieceType.Pawn, 'A', 0, 0);
            this.chessPieces['B'] = new ChessPiece(ChessPieceType.Pawn, 'B', 0, 2);
            this.chessPieces['C'] = new ChessPiece(ChessPieceType.Pawn, 'C', 0, 4);
            this.chessPieces['D'] = new ChessPiece(ChessPieceType.Pawn, 'D', 0, 6);
        }

        /// <summary>
        /// Gets the number of moves made by the king.
        /// </summary>
        public int KingMovesCount
        {
            get
            {
                return this.chessPieces[KingCharacter].MovesMade;
            }
        }

        /// <summary>
        /// Checks if the king wins.
        /// </summary>
        /// <remarks>The king wins when he is on the top row, or when
        /// none of the pawns can move any further.</remarks>
        /// <returns>True if the king wins, otherwise - false.</returns>
        public bool KingWins()
        {
            // the king has reached the top row
            if (this.chessPieces[KingCharacter].Row == 0)
            {
                return true;
            }

            // check if none of the pawns can move any further
            foreach (ChessPiece chessPiece in this.chessPieces.Values)
            {
                if (chessPiece.Type == ChessPieceType.Pawn)
                {
                    foreach (Move move in ValidPawnMoves.Values)
                    {
                        if (this.IsPositionValid(chessPiece.Row + move.DeltaRow, chessPiece.Col + move.DeltaCol))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the king loses.
        /// </summary>
        /// <remarks>The king loses when he cannot move in any direction
        /// from his current position.</remarks>
        /// <returns>True if the king loses, otherwise - false.</returns>
        public bool KingLoses()
        {
            ChessPiece king = this.chessPieces[KingCharacter];

            foreach (Move move in ValidKingMoves.Values)
            {
                if (this.IsPositionValid(king.Row + move.DeltaRow, king.Col + move.DeltaCol))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Parses the command and executes it if it is valid.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="kingsTurn">Specifies if it is the king's turn.</param>
        /// <returns>True if parsing and execution are successful, otherwise - false.</returns>
        public bool TryExecuteCommand(string command, bool kingsTurn)
        {
            if (!Commands.Contains(command))
            {
                return false;
            }

            if (kingsTurn)
            {
                if (!command.StartsWith(KingCharacter.ToString()))
                {
                    return false;
                }

                ChessPiece king = this.chessPieces[KingCharacter];
                Move move = ValidKingMoves[command.Substring(1)];

                if (this.IsPositionValid(king.Row + move.DeltaRow, king.Col + move.DeltaCol))
                {
                    this.UpdatePosition(king, move);
                    return true;
                }

                return false;
            }
            else
            {
                if (command.StartsWith(KingCharacter.ToString()))
                {
                    return false;
                }

                ChessPiece pawn = this.chessPieces[command[0]];
                Move move = ValidPawnMoves[command.Substring(1)];

                if (this.IsPositionValid(pawn.Row + move.DeltaRow, pawn.Col + move.DeltaCol))
                {
                    this.UpdatePosition(pawn, move);
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Returns a clone of one of the chess pieces on the board.
        /// </summary>
        /// <param name="character">The character of the chess piece.</param>
        /// <returns>A clone of the chess piece.</returns>
        public ChessPiece GetChessPiece(char character)
        {
            if (!this.chessPieces.ContainsKey(character))
            {
                throw new ArgumentException("Invalid character.", "character");
            }

            ChessPiece chessPiece = this.chessPieces[character];
            return (ChessPiece)chessPiece.Clone();
        }

        /// <summary>
        /// Returns the string representation of the chessboard.
        /// </summary>
        /// <returns>The board and the chess pieces on it as a string.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            StringBuilder colNumbersBuilder = new StringBuilder();
            StringBuilder dashedLineBuilder = new StringBuilder();

            for (int col = 0; col < ChessboardSize; col++)
            {
                colNumbersBuilder.Append(" " + col);
                dashedLineBuilder.Append("--");
            }

            dashedLineBuilder.Append("-");

            result.AppendLine("   " + colNumbersBuilder);
            result.AppendLine("   " + dashedLineBuilder);

            for (int row = 0; row < ChessboardSize; row++)
            {
                result.Append(row + " | ");

                for (int col = 0; col < ChessboardSize; col++)
                {
                    if (!this.IsPositionEmpty(row, col))
                    {
                        ChessPiece chessPiece = this.GetChessPiece(row, col);
                        result.Append(chessPiece.Character + " ");
                    }
                    else if ((row + col) % 2 == 0)
                    {
                        result.Append(WhiteSquareCharacter + " ");
                    }
                    else
                    {
                        result.Append(BlackSquareCharacter + " ");
                    }
                }

                result.AppendLine("|");
            }

            result.AppendLine("   " + dashedLineBuilder);
            return result.ToString();
        }

        private bool IsPositionOnTheChessboard(int row, int col)
        {
            return row >= 0 && row < ChessboardSize &&
                col >= 0 && col < ChessboardSize;
        }

        private bool IsPositionEmpty(int row, int col)
        {
            return !this.occupied[row, col];
        }

        private bool IsPositionValid(int row, int col)
        {
            return this.IsPositionOnTheChessboard(row, col) && this.IsPositionEmpty(row, col);
        }

        private void UpdatePosition(ChessPiece chessPiece, Move move)
        {
            this.occupied[chessPiece.Row, chessPiece.Col] = false;

            chessPiece.Row += move.DeltaRow;
            chessPiece.Col += move.DeltaCol;

            if (chessPiece.Type == ChessPieceType.King)
            {
                chessPiece.MovesMade++;
            }

            this.occupied[chessPiece.Row, chessPiece.Col] = true;
        }

        private ChessPiece GetChessPiece(int row, int col)
        {
            foreach (KeyValuePair<char, ChessPiece> pair in this.chessPieces)
            {
                ChessPiece chessPiece = pair.Value;

                if (chessPiece.Row == row && chessPiece.Col == col)
                {
                    return chessPiece;
                }
            }

            return null;
        }
    }
}