using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.BoardClasses;

namespace MonopolyTests
{
    /// <summary>
    /// Summary description for BoardTests
    /// </summary>
    [TestClass]
    public class BoardTests
    {
        public BoardTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateBoardWith40Spaces_BoardHas40Spaces()
        {
            Board board = new Board();
            Assert.AreEqual(40, board.NumberOfSquares);
        }

        [TestMethod]
        public void CreateBoard_GoIsAtPostionZero()
        {
            Board board = new Board();
            Assert.IsTrue(board.GetSquareAtPosition(0) is GoSquare);
        }

        [TestMethod]
        public void AllBoardSquaresAreFilled()
        {
            Board board = new Board();
            for (int i = 0; i < board.NumberOfSquares; i++)
                Assert.IsNotNull(board.GetSquareAtPosition(i));
        }

        [TestMethod]
        public void GetAllBoardSquaresInGroup_ReturnsCorrectSquares()
        {
            Board board = new Board();
            List<BoardSquare> groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Purple);
            Assert.AreEqual(2, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Light_Blue);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Light_Purple);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Orange);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Red);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Yellow);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Green);
            Assert.AreEqual(3, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Dark_Blue);
            Assert.AreEqual(2, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(PropertySquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Railroad);
            Assert.AreEqual(4, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(RailRoadSquare));

            groupSquares = board.GetAllBoardSquaresInGroup(OwnableSquare.PropertyGroup.Utility);
            Assert.AreEqual(2, groupSquares.Count);
            CheckSquareTypes(groupSquares, typeof(UtilitySquare));
        }

        private void CheckSquareTypes(List<BoardSquare> squares, Type expectedType)
        {
            foreach (BoardSquare square in squares)
                Assert.IsInstanceOfType(square, expectedType);
        }
    }
}
