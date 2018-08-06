using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly;
using Monopoly.DiceClasses;

namespace MonopolyTests
{
    /// <summary>
    ///This is a test class for RoundTest and is intended
    ///to contain all RoundTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RoundTest
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
        public void Round_CannotCompleteRoundWithoutCorrectNumberOfTurns()
        {
            Round rnd = new Round(4);

            Player player1 = new Player("Horse");
            Player player2 = new Player("Car");

            Dice dice = new Dice();
            Turn turn = new Turn(player1);
            turn.RollDice(dice);
            rnd.ArchiveTurn(new Turn(player1));

            turn = new Turn(player2);
            turn.RollDice(dice);
            rnd.ArchiveTurn(new Turn(player2));

            Assert.IsFalse(rnd.IsComplete);
        }

        [TestMethod()]
        public void Round_CannotPlayMoreTurnsThanPlayers()
        {
            Round rnd = new Round(4);
            Dice dice = new Dice();

            for (int i = 0; i < 5; i++)
            {
                Player player = new Player("Player " + i.ToString());
                Turn turn = new Turn(player);
                turn.RollDice(dice);
                rnd.ArchiveTurn(turn);
            }

            Assert.AreEqual(rnd.PlayerCount, rnd.TurnCount);
        }
    }
}
