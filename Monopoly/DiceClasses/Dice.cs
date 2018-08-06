using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.DiceClasses
{
    public class Dice : IDice
    {
        private const int numberOfDice = 2;
        public List<int> Rolls = new List<int>(numberOfDice);
        private int doublesCount;

        public Dice()
        {
            this.doublesCount = 0;
        }

        public int Roll()
        {
            this.Rolls.Clear();
            int totalRollValue = 0;
            Die die = new Die();

            for (int counter = 0; counter < numberOfDice; counter++)
            {
                int roll = die.Roll();
                Rolls.Add(roll);
                totalRollValue += roll;
            }

            if (IsDoubles)
                this.doublesCount++;
            else
                this.doublesCount = 0;

            return totalRollValue;
        }

        public bool IsDoubles
        {
            get { return Rolls[0] == Rolls[1]; }
        }

        public int DoublesCount
        {
            get { return this.doublesCount; }
        }

        public void ResetDoublesCount()
        {
            this.doublesCount = 0;
            this.Rolls.Clear();
        }
    }
}
