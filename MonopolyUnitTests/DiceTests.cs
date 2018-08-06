using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.DiceClasses;

namespace MonopolyTests
{
    /// <summary>
    /// Summary description for DiceTests
    /// </summary>
    [TestClass]
    public class DiceTests
    {
        public DiceTests()
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
        public void RollTwoDice_ReturnsValueBetween2And12()
        {
            Dice dice = new Dice();
            int value = dice.Roll();

            Assert.IsTrue(isValueInRange(value));
        }

        [TestMethod]
        public void RollTwoDice100Times_AlwaysReturnsValueBetween2And12()
        {
            for (int counter = 0; counter < 100; counter++)
            {
                Dice dice = new Dice();
                int value = dice.Roll();

                Assert.IsTrue(isValueInRange(value));
            }
        }

        private static bool isValueInRange(int value)
        {
            return value <= 12 && value >= 2;
        }

        [TestMethod]
        public void IsDoubles_ReturnsTrueWhenDoublesAreRolled()
        {
            Dice dice = new Dice();
            bool gotDoubles = false;

            while (!gotDoubles)
            {
                dice.Roll();
                gotDoubles = dice.Rolls[0] == dice.Rolls[1];
            }

            Assert.AreEqual(1, dice.DoublesCount);
        }

        [TestMethod]
        public void IsDoubles_ReturnsFalseWhenDoublesAreNotRolled()
        {
            Dice dice = new Dice();
            bool gotDoubles = true;

            while (gotDoubles)
            {
                dice.Roll();
                gotDoubles = dice.Rolls[0] == dice.Rolls[1];
            }

            Assert.AreEqual(0, dice.DoublesCount);
        }

        [TestMethod]
        public void Roll100Times_AtLeastOneSetOfDoublesIsRolled()
        {
            Dice dice = new Dice();

            for (int i = 0; i < 100; i++)
            {
                dice.Roll();
                if (dice.IsDoubles)
                    break;
            }

            Assert.AreNotEqual(0, dice.DoublesCount);
        }
        
    }
}
