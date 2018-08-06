using Monopoly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.BoardClasses;

namespace MonopolyTests
{
    
    
    /// <summary>
    ///This is a test class for BoardSquareTest and is intended
    ///to contain all BoardSquareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BoardSquareTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void CanCreateABoardSquare()
        {
            BoardSquare boardSquare = new BoardSquare();
            Assert.IsNotNull(boardSquare);
        }

        [TestMethod]
        public void CanCreateBoardSquareWithName()
        {
            BoardSquare boardSquare = new BoardSquare("bs");
            Assert.AreEqual("bs", boardSquare.Name);
        }

        [TestMethod]
        public void BoadSquare_ApplyEffectOnPass_RetunsFalse()
        {
            BoardSquare boardSquare = new BoardSquare();
            Assert.IsFalse(boardSquare.ApplyEffectOnPass);
        }

        [TestMethod]
        public void ChangeSetSquareName()
        {
            BoardSquare boardSquare = new BoardSquare();
            boardSquare.Name = "Marvin Gardens";
            Assert.AreEqual("Marvin Gardens", boardSquare.Name);
        }
    }
}
