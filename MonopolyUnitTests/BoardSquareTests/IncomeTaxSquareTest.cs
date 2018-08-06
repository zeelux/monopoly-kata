using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;

namespace MonopolyTests
{
    
    
    /// <summary>
    ///This is a test class for IncomeTaxSquareTest and is intended
    ///to contain all IncomeTaxSquareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IncomeTaxSquareTest
    {
        private IncomeTaxSquare taxSquare;

        [TestInitialize]
        public void InitializeTests()
        {
            taxSquare = new IncomeTaxSquare();
        }
        
        [TestMethod]
        public void IncomeTaxSquareConstructorTest()
        {
            Assert.IsNotNull(taxSquare);
        }

        [TestMethod]
        public void ApplyEffect_ChargesPlayer200WhenNetWorthOver2000()
        { 
            Board board = new Board();
            Player player = new Player("Player1");
            player.AddCash(4000);

            taxSquare.ApplyEffect(board, player, 2);
            Assert.AreEqual(3800, player.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges200WhenNetWorthEquals2000()
        {
            Board board = new Board();
            Player player = new Player("Player1");
            player.AddCash(2000);

            taxSquare.ApplyEffect(board, player, 2);
            Assert.AreEqual(1800, player.CashOnHand);
        }

        [TestMethod]
        public void ApplyEffect_Charges10PercentWhenNetLessThan2000()
        {
            Board board = new Board();
            Player player = new Player("Player1");
            player.AddCash(1000);

            taxSquare.ApplyEffect(board, player, 2);
            Assert.AreEqual(900, player.CashOnHand);
        }
    }
}
