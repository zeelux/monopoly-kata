using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class UtilitySquare : OwnableSquare
    {
        public UtilitySquare(string name, int price, PropertyGroup propertyGroup)
            : base(name, price, propertyGroup)
        { }


        public override void ApplyEffect(Board board, Player player, int roll)
        {
            if (base.Owner == null || base.Owner == player)
                return;

            int multiple = 4;
            List<BoardSquare> utilities = board.GetAllBoardSquaresInGroup(PropertyGroup.Utility);
            if (((OwnableSquare)utilities[0]).Owner != null && ((OwnableSquare)utilities[1]).Owner != null)
                multiple = 10;

            player.PayCash(roll * multiple);
            this.Owner.AddCash(roll * multiple);
        }
    }
}
