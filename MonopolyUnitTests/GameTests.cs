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
    /// Summary description for GameTests
    /// </summary>
    [TestClass]
    public class GameTests
    {
        public GameTests()
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
        public void Game_CanAddPlayer()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));

            Assert.IsTrue(game.PlayerCount == 1);
        }

        [TestMethod]
        public void GamePlayers_CanNotStartGameWithLessThan2Players()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            game.StartNewGame();
            Assert.IsFalse(game.IsActive);
        }

        [TestMethod]
        public void GamePlayers_CanNotStartGameWithNoPlayers()
        {
            Game game = new Game();
            game.StartNewGame();
            Assert.IsFalse(game.IsActive);
        }

        [TestMethod]
        public void GamePlayers_CanNotStartGameWithGreaterThan8Players()
        {
            Game game = new Game();

            for (int i = 0; i < 10; i++)
            {
                game.AddPlayer(new Player(i.ToString()));
            }

            game.StartNewGame();
            Assert.IsFalse(game.IsActive);
        }

        [TestMethod]
        public void GamePlayers_CanStartGameWithValidPlayerCount()
        {
            Game game = new Game();

            for (int i = 0; i < 5; i++)
            {
                game.AddPlayer(new Player("Player " + i.ToString()));
            }

            game.StartNewGame();
            Assert.IsTrue(game.IsActive);
        }

        [TestMethod]
        public void GetPlayer_ReturnsPlayerObject()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            Player player = game.GetPlayer(0);
            Assert.IsNotNull(player);
            Assert.AreEqual("Horse", player.Name);
        }

        [TestMethod]
        public void StartGame_RandomPlayOrder()
        {
            bool orderChanged = false;
            for (int counter = 0; counter < 100; counter++)
            {
                Game game = new Game();
                game.AddPlayer(new Player("Horse"));
                game.AddPlayer(new Player("Car"));

                game.StartNewGame();

                if (game.GetPlayer(0).Name != "Horse")
                {
                    orderChanged = true;
                    break;
                }
                
            }

            Assert.IsTrue(orderChanged);
        }

        [TestMethod]
        public void Game_CannotAddTwoPlayersWithSameName()
        {
            Game game = new Game();
            game.AddPlayer(new Player("Horse"));
            try
            {
                game.AddPlayer(new Player("Horse"));
                Assert.Fail("Able to add same player name twice with no exception.");
            }
            catch (ArgumentException)
            {                
            }
        }


        [TestMethod]
        public void Game_CanPlayGameWith20Rounds()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(2);
            gameController.PlayXRounds(20);

            Assert.AreEqual(20, gameController.Game.RoundCount);
        }

        [TestMethod]
        public void PlayGameWith20Rounds_EachPlayerPlayed20Turns()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(2);
            gameController.PlayXRounds(20);

            for (int player = 0; player < gameController.Game.PlayerCount; player++)
            {
                Assert.AreEqual(gameController.Game.RoundCount, gameController.Game.GetTurnCountForPlayer(player));
            }
            
        }

        [TestMethod]
        public void VerifyPlayerOrderDoesntChange()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(2);
            gameController.PlayXRounds(20);

            for (int rndCount = 0; rndCount < gameController.Game.RoundCount; rndCount++)
            {
                Round round = gameController.Game.GetRound(rndCount);
                for (int turnCount = 0; turnCount < round.TurnCount; turnCount++)
                {
                    Turn turn = round.GetTurn(turnCount);
                    Assert.AreEqual(turn.Player, gameController.Game.GetPlayer(turnCount));
                }
            }
        }


        [TestMethod]
        public void GameStart_PlayersHaveZeroCash()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);
            
            for (int playerNumber = 0; playerNumber < gameController.Game.PlayerCount; playerNumber++)
            {
                Assert.AreEqual(0, gameController.Game.GetPlayer(playerNumber).CashOnHand);
            }
        }

        [TestMethod]
        public void GameReStart_PlayersHaveZeroCash()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);
            gameController.Game.GetPlayer(0).AddCash(200);
            gameController.StartNewGame(4);

            for (int playerNumber = 0; playerNumber < gameController.Game.PlayerCount; playerNumber++)
            {
                Assert.AreEqual(0, gameController.Game.GetPlayer(playerNumber).CashOnHand);
            }
        }
    }
}
