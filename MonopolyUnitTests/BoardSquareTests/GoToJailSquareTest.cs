using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class GoToJailSquareTest
    {
        [TestMethod]
        public void GoToJailSquareConstructorTest()
        {
            GoToJailSquare jailSquare = new GoToJailSquare();
            Assert.IsNotNull(jailSquare);
        }

        [TestMethod]
        public void GoToJailSquare_SendsPlayerToJustVisitingSquare()
        {
            Board board = new Board();
            Player player1 = new Player("Player 1");
            
            GoToJailSquare jailSquare = new GoToJailSquare();
            jailSquare.ApplyEffect(board, player1, 0);
            Assert.AreEqual(10, player1.Location);
        }

        [TestMethod]
        public void GoToJailSquare_DoesNotChargePlayerAnyMoney()
        {
            Board board = new Board();
            Player player1 = new Player("Player 1");
            player1.AddCash(2000);

            GoToJailSquare jailSquare = new GoToJailSquare();
            jailSquare.ApplyEffect(board, player1, 0);
            Assert.AreEqual(2000, player1.CashOnHand);
        }

    }
}
