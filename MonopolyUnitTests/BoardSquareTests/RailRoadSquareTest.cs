using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class RailRoadSquareTest
    {
        private const string railroadName = "Reading Railroad";
        private RailRoadSquare railroadSquare;

        [TestInitialize]
        public void MyTestInitialize()
        {
            railroadSquare = new RailRoadSquare(railroadName);
        }
    
        [TestMethod]
        public void RailRoadSquareConstructor_SetsPriceTo200()
        {            
            Assert.AreEqual(200, railroadSquare.Price);
        }

        [TestMethod]
        public void RailRoadSquareConstructor_SetsValueForName()
        {
            Assert.AreEqual(railroadName, railroadSquare.Name);
        }

        [TestMethod]
        public void RailRoadSquareConstructor_SetsPropertyGroupToRailroad()
        {
            Assert.AreEqual(OwnableSquare.PropertyGroup.Railroad, railroadSquare.Group);
        }

        [TestMethod]
        public void RailRoadSquareConstructor_SetsOwnerToNull()
        {
            Assert.IsNull(railroadSquare.Owner);
        }

        [TestMethod]
        public void RailRoadSquareConstructor_SetsApplyEffectOnPassToFalse()
        {
            Assert.IsFalse(railroadSquare.ApplyEffectOnPass);
        }

        [TestMethod]
        public void ApplyEffect_DoesNotChangePlayersCashOnHandWhenRailroadIsUnowned()
        {
            Player player = new Player("Player 1");
            player.AddCash(2000);

            Board board = new Board();
            railroadSquare = (RailRoadSquare)board.GetSquareAtPosition(5);
            railroadSquare.ApplyEffect(board, player, 0);

            Assert.AreEqual(2000, player.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges25DollarsRentWhenOwnedByAnotherPlayer()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            railroadSquare = (RailRoadSquare)board.GetSquareAtPosition(5);
            railroadSquare.Owner = player1;

            railroadSquare.ApplyEffect(board, player2, 0);
            Assert.AreEqual(1975, player2.CashOnHand);
            Assert.AreEqual(2025, player1.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges50DollarsRentWhenTwoOwnedByAnotherPlayer()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            railroadSquare = (RailRoadSquare)board.GetSquareAtPosition(5);
            railroadSquare.Owner = player1;

            RailRoadSquare railroadSquare2 = (RailRoadSquare)board.GetSquareAtPosition(15);
            railroadSquare2.Owner = player1;

            railroadSquare.ApplyEffect(board, player2, 0);
            Assert.AreEqual(1950, player2.CashOnHand);
            Assert.AreEqual(2050, player1.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges100DollarsRentWhenThreeOwnedByAnotherPlayer()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            railroadSquare = (RailRoadSquare)board.GetSquareAtPosition(5);
            railroadSquare.Owner = player1;

            RailRoadSquare railroadSquare2 = (RailRoadSquare)board.GetSquareAtPosition(15);
            railroadSquare2.Owner = player1;

            RailRoadSquare railroadSquare3 = (RailRoadSquare)board.GetSquareAtPosition(25);
            railroadSquare3.Owner = player1;

            railroadSquare.ApplyEffect(board, player2, 0);
            Assert.AreEqual(1900, player2.CashOnHand);
            Assert.AreEqual(2100, player1.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges200DollarsRentWhenFourOwnedByAnotherPlayer()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            railroadSquare = (RailRoadSquare)board.GetSquareAtPosition(5);
            railroadSquare.Owner = player1;

            RailRoadSquare railroadSquare2 = (RailRoadSquare)board.GetSquareAtPosition(15);
            railroadSquare2.Owner = player1;

            RailRoadSquare railroadSquare3 = (RailRoadSquare)board.GetSquareAtPosition(25);
            railroadSquare3.Owner = player1;

            RailRoadSquare railroadSquare4 = (RailRoadSquare)board.GetSquareAtPosition(35);
            railroadSquare4.Owner = player1;

            railroadSquare.ApplyEffect(board, player2, 0);
            Assert.AreEqual(1800, player2.CashOnHand);
            Assert.AreEqual(2200, player1.CashOnHand);
        }
    }
}
