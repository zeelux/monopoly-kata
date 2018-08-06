using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class GoSquare : BoardSquare
    {
        public GoSquare() : base("Go")
        { 
        
        }

        public override bool ApplyEffectOnPass
        {
            get
            {
                return true;
            }            
        }

        public override void ApplyEffect(Board board, Player player, int roll)
        {
            player.AddCash(200);
        }
    }
}
