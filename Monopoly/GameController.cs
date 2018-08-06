using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.BoardClasses;
using Monopoly.DiceClasses;

namespace Monopoly
{
    public class GameController
    {
        private Game game;
        private IDice dice;
        private Board board;
        private Movement movement;
        private Player currentPlayer;
        private Turn currentTurn;

        public Board Board
        {
            get { return board; }
        }

        public IDice Dice
        {
            get { return dice; }
        }

        public Game Game
        {
            get { return game; }
        }

        public Movement Movement
        {
            get { return this.movement; }
        }

        public Turn CurrentTurn
        {
            get { return this.currentTurn; }
        }

        public GameController(IDice dice)
        {
            this.dice = dice;
            this.board = new BoardClasses.Board();
            this.movement = new Movement(this.board);
        }

        public void StartNewGame(int NumberOfPlayers)
        {
            this.game = SetupGameWithXPlayers(NumberOfPlayers);
        }

        public void PlayXRounds(int NumberOfRounds)
        {
            for (int roundCount = 0; roundCount < NumberOfRounds; roundCount++)
                PlayRound();
        }

        public void PlayRound()
        {
            Round round = new Round(game.PlayerCount);
            for (int playerIndex = 0; playerIndex < game.PlayerCount; playerIndex++)
            {
                this.currentPlayer = game.GetPlayer(playerIndex);    
                PlayTurn(round);
            }
            game.ArchiveRound(round);
        }

        public void PlayTurn(Round round)
        {
            this.currentTurn = new Turn(currentPlayer);
            this.dice.ResetDoublesCount();

            if (!currentPlayer.IsInJail)
                PlayRegularTurn();
            else
                PlayTurnFromInJail();
            
            round.ArchiveTurn(this.currentTurn);
        }

        private void PlayRegularTurn()
        {
            do
            {
                this.currentTurn.RollDice(this.dice);

                if (this.dice.DoublesCount == 3)
                {
                    this.movement.MovePlayerToJail(currentPlayer);
                    break;
                }

                MovePlayerAndBuyProperty();

                if (currentPlayer.IsInJail)
                    break;

            } while (this.dice.IsDoubles);
        }

        private void PlayTurnFromInJail()
        {
            this.currentPlayer.TurnsInJail++;
            this.currentTurn.RollDice(this.dice);

            if (this.dice.IsDoubles)
            {
                currentPlayer.IsInJail = false;
                MovePlayerAndBuyProperty();
            }
            else if (!this.dice.IsDoubles && this.currentPlayer.TurnsInJail == 3)
            {
                currentPlayer.PayCash(50);
                currentPlayer.IsInJail = false;
                MovePlayerAndBuyProperty();
            }
        }

        private void MovePlayerAndBuyProperty()
        {
            MovePlayer(currentPlayer, this.currentTurn);
            BuyPropertyIfUnowned(currentPlayer);
        }

        private void MovePlayer(Player currentPlayer, Turn turn)
        {
            movement.MovePlayer(currentPlayer, turn.GetLastRoll());

            ApplyEffectForCurrentPosition(currentPlayer, turn.GetLastRoll());
        }

        public void ApplyEffectForCurrentPosition(Player currentPlayer, int roll)
        {
            board.GetSquareAtPosition(currentPlayer.Location).ApplyEffect(board, currentPlayer, roll);
        }

        public void BuyPropertyIfUnowned(Player currentPlayer)
        {
            if (board.GetSquareAtPosition(currentPlayer.Location) is PropertySquare)
            {
                PropertySquare propertySquare = (PropertySquare)board.GetSquareAtPosition(currentPlayer.Location);
                if (propertySquare.Owner == null)
                    currentPlayer.BuyProperty(propertySquare);
            }
        }

        private Game SetupGameWithXPlayers(int playerCount)
        {
            Game game = new Game();

            for (int playerNumber = 0; playerNumber < playerCount; playerNumber++)
                game.AddPlayer(new Player("Player " + playerNumber.ToString()));

            game.StartNewGame();
            this.currentPlayer = game.GetPlayer(0);

            return game;
        }
    }
}
