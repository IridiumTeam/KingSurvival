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
        #region TryExecuteCommand Tests
        
        [TestMethod]
        public void TestTryExecuteCommandInvalidCommand()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            bool success = chessboardManager.TryExecuteCommand("qwerty", true);
            
            Assert.IsFalse(success, "Command execution returns success for invalid commands.");
        }
        
        [TestMethod]
        public void TestTryExecuteCommandInvalidCommandForKingWhenKingsTurn()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            bool success = chessboardManager.TryExecuteCommand("ADL", true);
            
            Assert.IsFalse(success, "Command execution returns success for invalid commands.");
        }
        
        [TestMethod]
        public void TestTryExecuteCommandCommandValidCommandKingUpLeft()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            bool success = chessboardManager.TryExecuteCommand("KUL", true);
            
            Assert.IsTrue(success, "Command execution fails for the valid command \"KUL\".");
        }
        
        [TestMethod]
        public void TestTryExecuteCommandValidCommandKingUpRight()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            bool success = chessboardManager.TryExecuteCommand("KUR", false);
            
            Assert.IsFalse(success, "Command execution returns success for \"KUR\" when it's not the king's turn.");
        }
        
        [TestMethod]
        public void TestTryExecuteCommandPawnDownRight()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            bool success = chessboardManager.TryExecuteCommand("ADR", false);
            
            Assert.IsTrue(success, "Command execution fails for the valid command \"ADR\".");
        }
        
        #endregion
        
        #region KingMovesCount test
        
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
        
        #endregion
        
        #region KingWins Tests
        
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
                
            Assert.IsTrue(chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }
        
        [TestMethod]
        public void TestKingWinsCaseSecond()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("BDL", false);

            chessboardManager.TryExecuteCommand("KUL", true);

            chessboardManager.TryExecuteCommand("CDL", false);

            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("DDL", false);

            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("DDL", false);

            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("CDL", false);

            chessboardManager.TryExecuteCommand("KUL", true);

            chessboardManager.TryExecuteCommand("BDL", false);

            chessboardManager.TryExecuteCommand("KUL", true);
                
            Assert.IsTrue(chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }
        
        [TestMethod]
        public void TestKingWinsCaseThird()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryExecuteCommand("KUL", true);

            chessboardManager.TryExecuteCommand("ADR", false);
            
            chessboardManager.TryExecuteCommand("KDL", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUL", true);

            chessboardManager.TryExecuteCommand("ADR", false);
            
            chessboardManager.TryExecuteCommand("KDR", true);
            //5, 1
            chessboardManager.TryExecuteCommand("KUL", true);

            chessboardManager.TryExecuteCommand("KUR", true);
            
            chessboardManager.TryExecuteCommand("DDR", false);
            chessboardManager.TryExecuteCommand("KUL", true);
            //1, 5
            chessboardManager.TryExecuteCommand("CDR", false);
            //3, 1
            chessboardManager.TryExecuteCommand("KUR", true);
            //1, 3
            chessboardManager.TryExecuteCommand("BDR", false);
            //2, 0
            chessboardManager.TryExecuteCommand("KUL", true);
            
            chessboardManager.TryExecuteCommand("DDL", false);
            //1, 1
            chessboardManager.TryExecuteCommand("KUR", true);

            chessboardManager.TryExecuteCommand("KUR", true);
                
            Assert.IsTrue(chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }
        
        [TestMethod]
        public void TestKingWinsWithNoValidPawnsMoves()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            //reaches line 7 
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            
            //reaches line 7 
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDL", false);
            chessboardManager.TryExecuteCommand("BDL", false);
            
            //reaches line 7 
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDR", false);
            chessboardManager.TryExecuteCommand("CDR", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            
            //this pawn is blocked at line 6, row 0 by pawn C which is at line 7, col 1
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            
            //the King does not need to reach row 0 to win  
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
                
            Assert.IsTrue(chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }
        
        [TestMethod]
        public void TestKingWinsWithValidPawnsMovesAndKingNotAtTheFinalRow()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            //all pawns have valid moves
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            chessboardManager.TryExecuteCommand("ADR", false);
            
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDR", false);
            chessboardManager.TryExecuteCommand("BDL", false);
            
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDL", false);
            chessboardManager.TryExecuteCommand("CDR", false);
            chessboardManager.TryExecuteCommand("CDR", false);
            
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            chessboardManager.TryExecuteCommand("DDL", false);
            
            //the King does not reach row 0
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
                
            Assert.IsFalse(chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        #endregion
        
        #region KingLoses Tests
        
        [TestMethod]
        public void TestKingLosesCaseFirstTrue()
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
        
            Assert.IsTrue(chessboardManager.KingLoses(),
                "The check whether the king loses doesn't work correctly.");
        }
        
        [TestMethod]
        public void TestKingLosesCaseSecondFalse()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
            
            // move the king to (2, 2)
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUL", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            chessboardManager.TryExecuteCommand("KUR", true);
            
            // move pawn A to (1, 1)
            chessboardManager.TryExecuteCommand("ADR", false);
            
            // move pawn B to (3, 1)
            chessboardManager.TryExecuteCommand("BDR", false);
            
            // move pawn C to (1, 5)
            chessboardManager.TryExecuteCommand("CDR", false);
            
            // move pawn D to (1, 7)
            chessboardManager.TryExecuteCommand("DDR", false);
        
            Assert.IsFalse(chessboardManager.KingLoses(),
                "The check whether the king loses doesn't work correctly.");
        }
        
        #endregion
        
        #region GetChessPiece Test 
            
        [TestMethod]
        public void TestGetChessPieceByCharacter()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            ChessPiece chessPiece = new ChessPiece(ChessPieceType.Pawn, 'K', 7, 3);
                
            ChessPiece clonedChessPiece = chessboardManager.GetChessPiece('K');
                
            Assert.AreEqual(
                clonedChessPiece.Character,
                chessPiece.Character,
                "GetChessPiece by character method doesn't work!");
            Assert.AreEqual(
                clonedChessPiece.Row,
                chessPiece.Row,
                "GetChessPiece by character method doesn't work!");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetChessPieceByCharacterException()
        {
            ChessboardManager chessboardManager = new ChessboardManager();
        
            ChessPiece clonedChessPiece = chessboardManager.GetChessPiece('E');
        }
        
        #endregion
        
        #region ToString Tests

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

        #endregion
    }
}