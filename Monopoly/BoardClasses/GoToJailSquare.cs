using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class GoToJailSquare : BoardSquare
    {
        public GoToJailSquare() : base("Go To Jail")
        { 
        
        }

        public override void ApplyEffect(Board board, Player player, int roll)
        {
            Movement movement = new Movement(board);
            movement.MovePlayerToJail(player);
        }
    }
}
