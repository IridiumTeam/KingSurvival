using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace KingSurvivalUnitTests
{
    /// <summary>
    /// Used to test the <see cref="Game"/> class functionality.
    /// </summary>
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestRunWithIORedirected()
        {
            Game.RunWithIORedirected(
                Properties.Resources.SampleInput,
                Properties.Resources.SampleOutput);

            CollectionAssert.AreEqual(
                Properties.Resources.ExpectedOutput,
                Properties.Resources.SampleOutput);
        }
    }
}
