using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;
using Monopoly.DiceClasses;

namespace MonopolyTests
{
    /// <summary>
    ///This is a test class for TurnTest and is intended
    ///to contain all TurnTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TurnTest
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

        [TestMethod()]
        public void TurnConstructorTest()
        {
            Player player1 = new Player("Horse");
            Dice dice = new Dice();
            int roll = dice.Roll();

            Turn turn = new Turn(player1);
            turn.RollDice(dice);
            Assert.AreEqual(player1, turn.Player);           
        }

        [TestMethod]
        public void LastRoll_ReturnsLastRollValue()
        {
            Dice dice = new Dice();
            Turn turn = new Turn(new Player("Horse"));
            turn.RollDice(dice);

        }

        
    }
}
