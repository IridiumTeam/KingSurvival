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
    /// Used to test the <see cref="GamePiece"/> class functionality.
    /// </summary>
    [TestClass]
    public class GamePieceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGamePieceConstructorNullCharacter()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.King, ' ', 3, 3);
        }

        [TestMethod]
        public void TestGamePieceConstructorValidParametersForKing()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.King, 'K', 3, 3);

            Assert.IsInstanceOfType(chessPiece, typeof(ChessPiece), "GamePiece constructor doesn't return an instance of GamePiece!");
            Assert.AreEqual(chessPiece.Type, ChessPieceType.King);
            Assert.AreEqual(chessPiece.Character, 'K');
            Assert.AreEqual(chessPiece.Row, 3);
            Assert.AreEqual(chessPiece.Col, 3);
        }

        [TestMethod]
        public void TestGamePieceConstructorValidParametersForPawn()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.Pawn, 'A', 7, 7);

            Assert.IsInstanceOfType(chessPiece, typeof(ChessPiece), "GamePiece constructor doesn't return an instance of GamePiece!");
            Assert.AreEqual(chessPiece.Type, ChessPieceType.Pawn);
            Assert.AreEqual(chessPiece.Character, 'A');
            Assert.AreEqual(chessPiece.Row, 7);
            Assert.AreEqual(chessPiece.Col, 7);
        }

        [TestMethod]
        public void TestGamePieceClone()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.Pawn, 'A', 7, 7);

            ChessPiece newChessPiece = (ChessPiece)chessPiece.Clone();

            Assert.AreEqual(chessPiece.Row, newChessPiece.Row);
            Assert.AreEqual(chessPiece.Col, newChessPiece.Col);
            Assert.AreEqual(chessPiece.Character, newChessPiece.Character);
            Assert.AreEqual(chessPiece.Type, newChessPiece.Type);
        }
    }
}