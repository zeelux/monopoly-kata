using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.DiceClasses
{
    public class Die
    {
        public int Roll()
        {
            return Randomizer.GetInstance().GetNext(5) + 1;
        }

    }
}
