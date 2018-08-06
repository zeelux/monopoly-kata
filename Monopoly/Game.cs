using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Game
    {
        private List<Player> players;
        private bool isActive;

        public Game()
        {
            this.players = new List<Player>();
            this.isActive = false;
        }

        public void AddPlayer(Player player)
        {
            foreach (Player plyr in this.players)
                if (plyr.Name == player.Name)
                    throw new ArgumentException("A player already exists in this game with the same name.");

            this.players.Add(player);
        }

        public void StartNewGame()
        {
            if (this.players.Count > 1 && this.players.Count < 9)
            {
                this.isActive = true;
                this.rounds = new List<Round>();
                RandomizePlayerOrder();
                ResetPlayerCashOnHand();
            }
        }

        private void ResetPlayerCashOnHand()
        {
            foreach (Player player in this.players)
                player.Initialize();
        }

        private void RandomizePlayerOrder()
        {
            List<Player> orderedPlayers = new List<Player>(this.players.Count);            

            while (this.players.Count > 0)
            {
                int r = Randomizer.GetInstance().GetNext(this.players.Count);
                orderedPlayers.Add(this.players[r]);
                this.players.RemoveAt(r);
            }

            this.players.AddRange(orderedPlayers);
        }

        public int PlayerCount
        {
            get { return this.players.Count; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
        }

        private List<Round> rounds;

        public int RoundCount 
        {
            get { return rounds.Count; }
        }

        public Player GetPlayer(int index)
        {
            return this.players[index];
        }

        public void ArchiveRound(Round r)
        {
            this.rounds.Add(r);
        }

        public int GetTurnCountForPlayer(int playerNumber)
        {
            Player player = GetPlayer(playerNumber);
            int turnCount = 0;

            foreach (Round rnd in this.rounds)
                if (rnd.GetTurnForPlayer(player) != null)
                    turnCount++;
            
            return turnCount;
        }

        public Round GetRound(int roundCount)
        {
            if (roundCount >= 0 && roundCount < this.rounds.Count)
                return this.rounds[roundCount];
            return null;
        }

        public Round GetLastRound()
        {
            if (this.rounds.Count > 0)
                return this.rounds[this.rounds.Count - 1];
            return null;
        }
    }
}
