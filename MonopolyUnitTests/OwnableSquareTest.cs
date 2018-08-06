using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MonopolyTests
{
    [TestClass]
    public class OwnableSquareTest
    {
        [TestMethod]
        public void OwnableSquareConstructor_PriceDefaultsToZero()
        {
            OwnableSquare ownableSquare = new OwnableSquare();
            Assert.AreEqual(0, ownableSquare.Price);
        }

        [TestMethod]
        public void OwnableSquareConstructor_MortgagedDefaultsToFalse()
        {
            OwnableSquare ownableSquare = new OwnableSquare();
            Assert.IsFalse(ownableSquare.Mortgaged);
        }

        [TestMethod]
        public void OwnableSquareConstructor_InitializesValues()
        {            
            OwnableSquare ownableSquare = new OwnableSquare("Boardwalk", 400, PropertySquare.PropertyGroup.Dark_Blue);
            Assert.AreEqual("Boardwalk", ownableSquare.Name);
            Assert.AreEqual(400, ownableSquare.Price);
            Assert.AreEqual(PropertySquare.PropertyGroup.Dark_Blue, ownableSquare.Group);
        }

        [TestMethod]
        public void CanChangeMortgagedProperty()
        {
            OwnableSquare ownableSquare = new OwnableSquare();
            ownableSquare.Mortgaged = true;
            Assert.IsTrue(ownableSquare.Mortgaged);
            ownableSquare.Mortgaged = false;
            Assert.IsFalse(ownableSquare.Mortgaged);
        }
    }
}
