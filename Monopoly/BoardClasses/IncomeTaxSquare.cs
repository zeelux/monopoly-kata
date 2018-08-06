using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class IncomeTaxSquare : BoardSquare
    {
        public IncomeTaxSquare() : base("Income Tax")
        {

        }

        public override void ApplyEffect(Board board, Player player, int roll)
        {
            if (player.TotalWorth < 2000)
                player.PayCash((int)Math.Round(player.CashOnHand * .1));
            else
                player.PayCash(200);
        }
    }
}
