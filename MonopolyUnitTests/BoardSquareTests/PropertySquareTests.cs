using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.BoardClasses;

namespace MonopolyTests.BoardSquareTests
{
    [TestClass]
    public class PropertySquareTests
    {
        [TestMethod]
        public void SetPriceTo100_PriceIs100()
        {
            PropertySquare propertySquare = new PropertySquare();
            propertySquare.Price = 100;
            Assert.AreEqual(100, propertySquare.Price);
        }

        [TestMethod]
        public void PropertySquareConstructor_SetsNamePriceAndGroup()
        {
            PropertySquare propertySquare = new PropertySquare("Boardwalk", 400, OwnableSquare.PropertyGroup.Dark_Blue, new int[] {0,1,2,3,4,5});
            Assert.AreEqual("Boardwalk", propertySquare.Name);
            Assert.AreEqual(400, propertySquare.Price);
            Assert.AreEqual(OwnableSquare.PropertyGroup.Dark_Blue, propertySquare.Group);
        }

        [TestMethod]
        public void PropertySquare_PriceDefaultsToZero()
        {
            PropertySquare propertySquare = new PropertySquare();
            Assert.AreEqual(0, propertySquare.Price);
        }

        [TestMethod]
        public void PropertySquare_DefaultOwnerIsNull()
        {
            PropertySquare propertySquare = new PropertySquare();
            Assert.IsNull(propertySquare.Owner);
        }

        [TestMethod]
        public void PropertySquare_CanSetOwner()
        {
            PropertySquare propertySquare = new PropertySquare();
            Player player = new Player("Horse");
            propertySquare.Owner = player;

            Assert.AreEqual(player, propertySquare.Owner);
        }

        [TestMethod]
        public void PropertySquare_RentIsStatedAmountWhenNotAllPropertiesAreOwned()
        {
            Board board = new Board();

            Player player1 = new Player("Player1");
            player1.AddCash(2000);

            Player player2 = new Player("Player2");
            player2.AddCash(2000);
            
            PropertySquare boardwalkSquare = (PropertySquare)board.GetSquareAtPosition(39);
            boardwalkSquare.Owner = player1;

            boardwalkSquare.ApplyEffect(board, player2, 2);

            Assert.AreEqual(1950, player2.CashOnHand);
            Assert.AreEqual(2050, player1.CashOnHand);
        }

        [TestMethod]
        public void PropertySquare_RentIsDoubledWhenAllPropertiesAreOwnedButNoStructuresArePresent()
        {
            Board board = new Board();

            Player player1 = new Player("Player1");
            player1.AddCash(2000);

            Player player2 = new Player("Player2");
            player2.AddCash(2000);

            PropertySquare boardwalkSquare = (PropertySquare)board.GetSquareAtPosition(39);
            boardwalkSquare.Owner = player1;

            PropertySquare parkPlaceSquare = (PropertySquare)board.GetSquareAtPosition(37);
            parkPlaceSquare.Owner = player1;

            boardwalkSquare.ApplyEffect(board, player2, 2);

            Assert.AreEqual(1900, player2.CashOnHand);
            Assert.AreEqual(2100, player1.CashOnHand);
        }
    }
}
