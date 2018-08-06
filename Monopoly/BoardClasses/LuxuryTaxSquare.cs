using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class LuxuryTaxSquare : BoardSquare
    {
        public LuxuryTaxSquare()
            : base("Luxury Tax")
        { }


        public override void ApplyEffect(Board board, Player player, int roll)
        {
            player.PayCash(75);
        }
    }
}
