using Monopoly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.BoardClasses;
using Monopoly.DiceClasses;

namespace MonopolyTests
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void GameControllerConstructorTest()
        {
            IDice dice = new Dice();
            GameController controller = new GameController(dice);
            Assert.IsNotNull(controller);
            Assert.IsNotNull(controller.Dice);
            Assert.IsNotNull(controller.Board);
        }

        [TestMethod]
        public void GameController_CanStartAGame()
        {
            IDice dice = new Dice();
            GameController controller = new GameController(dice);
            controller.StartNewGame(4);

            Assert.IsNotNull(controller.Game);
        }

        [TestMethod]
        public void PlayerLandsOnGo_CashIncreasesBy200()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 38;
            player.AddCash(1000);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 2);

            Assert.AreEqual(1200, player.CashOnHand);  
        }

        [TestMethod]
        public void PlayerMovesPastGo_CashIncreasesBy200()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 38;
            player.AddCash(1000);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 5);

            Assert.AreEqual(1200, player.CashOnHand);  
        }

        [TestMethod]
        public void PlayerDoesNotPassGo_PlayerDoesNotCollect200Dollars()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 5;
            player.AddCash(1000);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 5);

            Assert.AreEqual(1000, player.CashOnHand);  
        }

        [TestMethod]
        public void PlayerPassesGoTwice_PlayerCollects400Dollars()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 38;
            player.AddCash(1000);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 5);
            movement.MovePlayer(player, 40);
            
            Assert.AreEqual(1400, player.CashOnHand);            
        }

        [TestMethod]
        public void PlayerLandsOnGoToJail_PlayerGoesToJailAndBalanceIsUnchanged()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 28;
            player.AddCash(123);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 2);

            gameController.ApplyEffectForCurrentPosition(player, 2);

            Assert.IsTrue(gameController.Board.GetSquareAtPosition(player.Location) is JustVisitingSquare);
            Assert.IsTrue(player.IsInJail);
            Assert.AreEqual(123, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerPassesGoToJailButDoesNotReachGo_DontGoToJailAndCashStaysSame()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 25;
            player.AddCash(123);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 10);

            gameController.ApplyEffectForCurrentPosition(player, 10);

            Assert.AreEqual(35, player.Location);
            Assert.AreEqual(123, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxWith1800TotalWorth_CashOnHandDecresesBy180()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 0;
            player.AddCash(1800);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 4);

            gameController.ApplyEffectForCurrentPosition(player, 4);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(1620, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxWith2200TotalWorth_CashOnHandDecresesBy200()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 0;
            player.AddCash(2200);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 4);

            gameController.ApplyEffectForCurrentPosition(player, 4);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(2000, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxWith0TotalWorth_CashOnHandStays0()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 0;
            player.AddCash(0);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 4);

            gameController.ApplyEffectForCurrentPosition(player, 4);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(0, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxWith2000TotalWorth_CashOnHandReducedBy200()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 0;
            player.AddCash(2000);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 4);

            gameController.ApplyEffectForCurrentPosition(player, 4);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(1800, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTax_CashOnHandStaysSame()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 0;
            player.AddCash(1500);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 8);

            gameController.ApplyEffectForCurrentPosition(player, 8);

            Assert.AreEqual(8, player.Location);
            Assert.AreEqual(1500, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnLuxuryTax_CashOnHandReduced75()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);
            
            Player player = gameController.Game.GetPlayer(0);
            player.Location = 31;
            player.AddCash(1500);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 7);

            gameController.ApplyEffectForCurrentPosition(player, 7);

            Assert.AreEqual(38, player.Location);
            Assert.AreEqual(1425, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerPassesOverLuxuryTax_CashOnHandRemainsSame()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 31;
            player.AddCash(1500);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 8);

            gameController.ApplyEffectForCurrentPosition(player, 8);

            Assert.AreEqual(39, player.Location);
            Assert.AreEqual(1500, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerPassesOverPropertySquare_CashOnHandRemainsSame()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(2);

            Player player = gameController.Game.GetPlayer(0);
            player.AddCash(1500);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 2);

            gameController.ApplyEffectForCurrentPosition(player, 2);

            Assert.AreEqual(2, player.Location);
            Assert.AreEqual(1500, player.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnOwnedPropertySquare_PlayerPaysRentIfNotOwner()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player = gameController.Game.GetPlayer(0);
            player.Location = 37;
            player.AddCash(400);


            ((PropertySquare)gameController.Board.GetSquareAtPosition(39)).Owner = gameController.Game.GetPlayer(1);
            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player, 2);
            gameController.ApplyEffectForCurrentPosition(player, 2);

            Assert.AreEqual(350, player.CashOnHand);
            Assert.AreEqual(50, gameController.Game.GetPlayer(1).CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnMortgagedProperty_NoRentIsCharged()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(4);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.Location = 37;
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            PropertySquare boardwalk = ((PropertySquare)gameController.Board.GetSquareAtPosition(39));
            boardwalk.Owner = gameController.Game.GetPlayer(1);
            boardwalk.Mortgaged = true;

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player1, 2);
            gameController.ApplyEffectForCurrentPosition(player1, 2);

            Assert.AreEqual(400, player1.CashOnHand);
            Assert.AreEqual(400, player2.CashOnHand);
        }

        [TestMethod]
        public void PlayerLandsOnUnownedProperty_PlayerBuysProperty()
        {
            IDice dice = new Dice();
            GameController gameController = new GameController(dice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Movement movement = new Movement(gameController.Board);
            movement.MovePlayer(player1, 3);
            gameController.ApplyEffectForCurrentPosition(player1, 3);
            gameController.BuyPropertyIfUnowned(player1);            
            
            Assert.AreEqual(340, player1.CashOnHand);
            Assert.AreEqual(400, player2.CashOnHand);
        }

        [TestMethod]
        public void PlayerRollsDoubles_PlayerContinuesRolling()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 4);
            loadedDice.AddRollValues(4, 4);
            loadedDice.AddRollValues(4, 3);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Round round = new Round(2);
            gameController.PlayTurn(round);
            Assert.AreEqual(3, round.GetTurnForPlayer(player1).RollCount);
        }

        [TestMethod]
        public void PlayerRollsDoubles3Times_PlayerGoesToJail()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 4);
            loadedDice.AddRollValues(5, 5);
            loadedDice.AddRollValues(6, 6);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Round round = new Round(2);
            gameController.PlayTurn(round);
            Assert.IsTrue(player1.IsInJail);
        }

        [TestMethod]
        public void PlayerRollsDoubles2Times_PlayerDoesNotGoToJail()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 4);
            loadedDice.AddRollValues(5, 5);
            loadedDice.AddRollValues(6, 3);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Round round = new Round(2);
            gameController.PlayTurn(round);
            Assert.IsFalse(player1.IsInJail);
        }

        [TestMethod]
        public void Player1RollsDoubles3Times_Player2DoesNotGoToJail()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 4);
            loadedDice.AddRollValues(5, 5);
            loadedDice.AddRollValues(6, 6);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Round round = new Round(2);
            gameController.PlayTurn(round);

            Round round2 = new Round(2);
            loadedDice.AddRollValues(1, 1);
            loadedDice.AddRollValues(2, 3);
            Assert.IsFalse(player2.IsInJail);
        }

        [TestMethod]
        public void PlayerIsInJailAndRollsDoubles_PlayerGetsOutOfJailAndDoesNotContinueRolling()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 4);
 
            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);
            player1.IsInJail = true;

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            Round round = new Round(2);
            gameController.PlayTurn(round);

            Assert.IsFalse(player1.IsInJail);
            Assert.AreEqual(1, round.GetTurnForPlayer(player1).RollCount);
        }

        [TestMethod]
        public void PlayerIsInJailAndRollsNoDoublesFor3Turns_PlayerGetsOutOfJailAndDoesNotContinueRolling()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 3);
            loadedDice.AddRollValues(4, 3);
            loadedDice.AddRollValues(4, 3);
            loadedDice.AddRollValues(4, 3);
            loadedDice.AddRollValues(4, 6);
            loadedDice.AddRollValues(1, 3);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);
            gameController.Movement.MovePlayerToJail(player1);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            gameController.PlayRound();
            gameController.PlayRound();
            gameController.PlayRound();

            Assert.IsFalse(player1.IsInJail);
            Assert.AreEqual(350, player1.CashOnHand);
            Assert.AreEqual(1, gameController.Game.GetLastRound().GetTurnForPlayer(player1).RollCount);
            Assert.AreEqual(20, player1.Location);
        }

        [TestMethod]
        public void PlayerIsInJailAndBuysTheirWayOut_PlayerGetsOutOfJailAndRolls()
        {
            LoadedDice loadedDice = new LoadedDice();
            loadedDice.AddRollValues(4, 3);
            loadedDice.AddRollValues(4, 3);

            loadedDice.AddRollValues(4, 6);
            loadedDice.AddRollValues(1, 3);

            GameController gameController = new GameController(loadedDice);
            gameController.StartNewGame(2);

            Player player1 = gameController.Game.GetPlayer(0);
            player1.AddCash(400);
            gameController.Movement.MovePlayerToJail(player1);

            Player player2 = gameController.Game.GetPlayer(1);
            player2.AddCash(400);

            gameController.PlayRound();

            player1.BuyMyWayOutOfJail();
            
            gameController.PlayRound();

            Assert.IsFalse(player1.IsInJail);
            Assert.AreEqual(350, player1.CashOnHand);
            Assert.AreEqual(1, gameController.Game.GetLastRound().GetTurnForPlayer(player1).RollCount);
            Assert.AreEqual(20, player1.Location);
        }
    }
}
