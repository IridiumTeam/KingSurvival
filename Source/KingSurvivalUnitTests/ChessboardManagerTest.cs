// ********************************
// <copyright file="ChessboardManagerTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvivalUnitTests
{
    using System;
    using KingSurvival;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="ChessboardManager"/> class functionality.
    /// </summary>
    [TestClass]
    public class ChessboardManagerTest
    {
        [TestMethod]
        public void TestTryExecuteCommandInvalidCommand()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryExecuteCommand("qwerty", true);

            Assert.AreEqual(false, success, "Command execution returns success for invalid commands.");
        }

        [TestMethod]
        public void TestTryExecuteCommandCommandValidCommandKingUpLeft()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryExecuteCommand("KUL", true);

            Assert.AreEqual(true, success, "Command execution fails for the valid command \"KUL\".");
        }

        [TestMethod]
        public void TestTryExecuteCommandValidCommandKingUpRight()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryExecuteCommand("KUR", false);

            Assert.AreEqual(false, success, "Command execution returns success for \"KUR\" when it's not the king's turn.");
        }

        [TestMethod]
        public void TestTryExecuteCommandPawnDownRight()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryExecuteCommand("ADR", false);

            Assert.AreEqual(true, success, "Command execution fails for the valid command \"ADR\".");
        }

        [TestMethod]
        public void TestKingMovesCount()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("CDR", false);

            chessboardManager.TryExecuteCommand("KUR", true);

            Assert.AreEqual(
                7,
                chessboardManager.KingMovesCount,
                "The moves made by the king are not counted correctly.");
        }

        [TestMethod]
        public void TestKingWinsCaseFirst()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("CDR", false);

            chessboardManager.TryExecuteCommand("KUR", true);

            Assert.AreEqual(
                true,
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingLosesCaseFirst()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            // move the king to (2, 2)
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);

            // move pawn A to (3, 1)
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADL", false);
            chessboardManager.TryExecuteCommand("ADR", false);

            // move pawn B to (1, 1)
            chessboardManager.TryExecuteCommand("BDL", false);

            // move pawn C to (1, 3)
            chessboardManager.TryExecuteCommand("CDL", false);

            // move pawn D to (3, 3)
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);

            Assert.AreEqual(
                true,
                chessboardManager.KingLoses(),
                "The check whether the king loses doesn't work correctly.");
        }

        [TestMethod]
        public void TestToStringStartScreen()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            string expectedString =
                "    0 1 2 3 4 5 6 7\r\n" +
                "   -----------------\r\n" +
                "0 | A - B - C - D - |\r\n" +
                "1 | - + - + - + - + |\r\n" +
                "2 | + - + - + - + - |\r\n" +
                "3 | - + - + - + - + |\r\n" +
                "4 | + - + - + - + - |\r\n" +
                "5 | - + - + - + - + |\r\n" +
                "6 | + - + - + - + - |\r\n" +
                "7 | - + - K - + - + |\r\n" +
                "   -----------------\r\n";

            Assert.AreEqual(
            expectedString,
            chessboardManager.ToString(),
            "Converting to string doesn't work correctly.");
        }
    }
}