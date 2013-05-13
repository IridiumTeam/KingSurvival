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
                    bool executionSuccessful = false;
                    string actor = kingsTurn ? "King" : "Pawns";

                    do
                    {
                        Console.Write("{0}'s turn: ", actor);
                        command = Console.ReadLine();
                        command = command.Trim().ToUpper();
                        executionSuccessful = chessboardManager.TryExecuteCommand(command, kingsTurn);
                        if (!executionSuccessful)
                        {
                            Console.WriteLine("Invalid move.");
                        }
                    }
                    while (!executionSuccessful);

                    kingsTurn = !kingsTurn;
                }
            }
        }
    }
}