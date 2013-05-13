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
    public class GamePieceTypeTest
    {
        [TestMethod]
        public void TestGamePieceTypeKing()
        {
            ChessPieceType chessPieceKing = ChessPieceType.King;

            Assert.AreEqual((int)chessPieceKing, 0);
        }
    }
}