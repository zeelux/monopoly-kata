using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Round
    {
        private int playerCount;        
        private List<Turn> turns;

        public int PlayerCount
        {
            get { return this.playerCount; }
        }
        public int TurnCount
        {
            get { return this.turns.Count; } 
        }
        public bool IsComplete
        {
            get { return this.playerCount == turns.Count; }
        }

        public Round(int numberOfPlayers)
        {
            this.playerCount = numberOfPlayers;
            this.turns = new List<Turn>(numberOfPlayers);
        }

        public void ArchiveTurn(Turn t)
        {
            if (IsComplete)
                return;

            turns.Add(t);
        }

        public Turn GetTurnForPlayer(Player player)
        { 
            foreach (Turn turn in this.turns)
            {
                if (turn.Player == player)
                    return turn;
            }

            return null;
        }

        public Turn GetTurn(int turnCount)
        {
            if (turnCount >= 0 && turnCount < this.turns.Count)
                return this.turns[turnCount];
            return null;
        }
    }
}
