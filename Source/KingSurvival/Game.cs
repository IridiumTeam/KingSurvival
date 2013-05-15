// ********************************
// <copyright file="Game.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    /// <summary>
    /// Used to initialize the game and perform the game loop.
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        private static void Main()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            Console.WriteLine(
                "KING SURVIVAL\n" +
                "The king has to reach the top row of the \n" +
                "chessboard without being caught by the pawns.\n" +
                "The valid commands are:\n" +
                chessboardManager.GetValidCommands());

            bool kingsTurn = true;

            while (true)
            {
                if (chessboardManager.KingWins())
                {
                    Console.WriteLine("King wins in {0} moves.", chessboardManager.KingMovesCount);
                    break;
                }
                else if (chessboardManager.KingLoses())
                {
                    Console.WriteLine("King loses in {0} moves.", chessboardManager.KingMovesCount);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(chessboardManager);

                    string command;
                    bool moveSuccessful = false;
                    string actor = kingsTurn ? "King" : "Pawn";

                    do
                    {
                        Console.Write("{0}'s turn: ", actor);
                        command = Console.ReadLine();
                        command = command.Trim().ToUpper();

                        if (kingsTurn)
                        {
                            moveSuccessful = chessboardManager.TryMoveKing(command);
                        }
                        else
                        {
                            moveSuccessful = chessboardManager.TryMovePawn(command);
                        }

                        if (!moveSuccessful)
                        {
                            Console.WriteLine("Invalid move.");
                        }
                    }
                    while (!moveSuccessful);

                    kingsTurn = !kingsTurn;
                }
            }
        }
    }
}