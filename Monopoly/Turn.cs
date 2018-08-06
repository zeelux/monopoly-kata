using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.DiceClasses;

namespace Monopoly
{
    public class Turn
    {
        private Player player;

        public Player Player
        {
            get { return player; }
        }

        private List<int> rolls;

        public int GetRoll(int rollIndex)
        {
            if (rolls.Count > rollIndex)
                return rolls[rollIndex];
            else
                throw new Exception(String.Format("Roll {0} does not exist.", rollIndex));
        }
        public int GetLastRoll()
        {
            if (rolls.Count > 0)
                return rolls[rolls.Count - 1];
            else
                throw new Exception("No rolls thrown yet.");
        }

        public Turn(Player player)
        {
            this.player = player;
            this.rolls = new List<int>();
        }

        public void RollDice(IDice dice)
        {
            int roll = dice.Roll();
            this.rolls.Add(roll);
        }

        public int RollCount { get { return this.rolls.Count; } }
    }
}
