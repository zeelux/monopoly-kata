using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    /// <summary>
    /// Summary description for PlayerTests
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        public PlayerTests()
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
        public void PlayerName_NotNull()
        {
            Player player = new Player("Player 1");
            Assert.IsNotNull(player.Name);
        }

        [TestMethod]
        public void PlayerName_IsSetByConstructor()
        {
            Player player = new Player("Horse");
            Assert.AreEqual("Horse", player.Name);
        }

        [TestMethod]
        public void PlayerIsInJail_IsSetByConstructor()
        {
            Player player = new Player("Horse");
            Assert.IsFalse(player.IsInJail);
        }

        [TestMethod]
        public void PlayerIsInJail_CanBeChanged()
        {
            Player player = new Player("Horse");
            player.IsInJail = true;
            Assert.IsTrue(player.IsInJail);
        }

        [TestMethod]
        public void PlayerName_CanBeChanged()
        {
            Player player = new Player("Horse");
            player.Name = "Car";
            Assert.AreEqual("Car", player.Name);
        }

        [TestMethod]
        public void PlayerLocation_StartsAtZero()
        {
            Player player = new Player("Horse");
            Assert.AreEqual(0, player.Location);
        }

        [TestMethod]
        public void PlayerLocation_CanBeChanged()
        {
            Player player = new Player("Car");
            player.Location = 15;
            Assert.AreEqual(15, player.Location);
        }

        [TestMethod]
        public void Player_StartsWithZeroDollars()
        {
            Player player = new Player("Horse");
            Assert.AreEqual(0, player.CashOnHand);
            Assert.AreEqual(0, player.TotalWorth);
        }

        [TestMethod]
        public void PlayerRecievesCash_TotalWorthIncreasesByValue()
        {
            Player player = new Player("Car");
            int previousCash = player.CashOnHand;
            int previousTotalWorth = player.TotalWorth;
            
            player.AddCash(500);
            Assert.AreEqual(previousCash + 500, player.CashOnHand);
            Assert.AreEqual(previousTotalWorth + 500, player.TotalWorth);

        }
    }
}
