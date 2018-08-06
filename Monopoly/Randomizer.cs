using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Randomizer
    {
        private static Randomizer randomizer;
        private Random random;

        private Randomizer()
        {
            random = new Random(DateTime.Now.Minute * DateTime.Now.Second * DateTime.Now.Millisecond);
        }

        public static Randomizer GetInstance()
        {
            if (randomizer == null)
                randomizer = new Randomizer();

            return randomizer;
        }

        public int GetNext(int MaxValue)
        {
            return this.random.Next(MaxValue);
        }
    }
}
