using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.DiceClasses
{
    public class LoadedDice : IDice
    {
        private const int numberOfDice = 2;
        public List<int> Rolls = new List<int>(numberOfDice);
        private int doublesCount;

        private Queue<Queue<int>> valuesToRoll;

        public LoadedDice()
        {
            this.doublesCount = 0;
            this.valuesToRoll = new Queue<Queue<int>>();
        }

        public void AddRollValues(int die1, int die2)
        { 
            Queue<int> rolls = new Queue<int>();
            rolls.Enqueue(die1);
            rolls.Enqueue(die2);

            valuesToRoll.Enqueue(rolls);
        }

        public int Roll()
        {
            this.Rolls.Clear();
            Queue<int> dieValues = valuesToRoll.Dequeue();

            int totalRollValue = 0;
            while (dieValues.Count > 0)
            {
                int roll = dieValues.Dequeue();
                Rolls.Add(roll);
                totalRollValue += roll;
            }

            if (this.IsDoubles)
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
