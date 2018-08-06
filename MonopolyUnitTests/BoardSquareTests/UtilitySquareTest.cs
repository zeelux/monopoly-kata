using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class UtilitySquareTest
    {
        private const string utilityName = "Electric Company";
        private UtilitySquare utilitySquare;

        [TestInitialize]
        public void MyTestInitialize()
        {
            utilitySquare = new UtilitySquare(utilityName, 160, OwnableSquare.PropertyGroup.Utility);
        }

        [TestMethod]
        public void UtilitySquareConstructor_SetsPrice()
        {
            Assert.AreEqual(160, utilitySquare.Price);
        }

        [TestMethod]
        public void UtilitySquareConstructor_SetsValueForName()
        {
            Assert.AreEqual(utilityName, utilitySquare.Name);
        }

        [TestMethod]
        public void UtilitySquareConstructor_SetsPropertyGroupToUtility()
        {
            Assert.AreEqual(OwnableSquare.PropertyGroup.Utility, utilitySquare.Group);
        }

        [TestMethod]
        public void UtilitySquareConstructor_SetsOwnerToNull()
        {
            Assert.IsNull(utilitySquare.Owner);
        }

        [TestMethod]
        public void UtilitySquareConstructor_SetsApplyEffectOnPassToFalse()
        {
            Assert.IsFalse(utilitySquare.ApplyEffectOnPass);
        }

        [TestMethod]
        public void ApplyEffect_Charges4TimesDiceRentWhenOwnedByAnotherPlayer()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            utilitySquare = (UtilitySquare)board.GetSquareAtPosition(12);
            utilitySquare.Owner = player1;

            utilitySquare.ApplyEffect(board, player2, 2);
            Assert.AreEqual(1992, player2.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges10TimesDiceRentWhenOwnedByAnotherPlayerAndOtherUtilityIsOwned()
        {
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            Player player2 = new Player("Player 2");
            player2.AddCash(2000);

            Board board = new Board();

            UtilitySquare electricCompany = (UtilitySquare)board.GetSquareAtPosition(12);
            electricCompany.Owner = player1;

            UtilitySquare waterWorks = (UtilitySquare)board.GetSquareAtPosition(28);
            waterWorks.Owner = player1;

            electricCompany.ApplyEffect(board, player2, 2);
            Assert.AreEqual(1980, player2.CashOnHand);
            Assert.AreEqual(2020, player1.CashOnHand);
        }
    }
}
