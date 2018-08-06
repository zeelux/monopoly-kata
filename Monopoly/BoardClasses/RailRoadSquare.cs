using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class RailRoadSquare : OwnableSquare
    {
        private const int purchasePrice = 200;
        private readonly int[] rentValues = new int[4] { 25, 50, 100, 200 };

        public RailRoadSquare(string name)
            : base(name, purchasePrice, PropertyGroup.Railroad)
        { }


        public override void ApplyEffect(Board board, Player player, int roll)
        {
            if (this.Owner == null)
                return;

            List<BoardSquare> groupSquares = board.GetAllBoardSquaresInGroup(PropertyGroup.Railroad);
            int squaresOwned = 0;
            
            foreach (RailRoadSquare square in groupSquares)
                if (square.Owner == this.Owner)
                    squaresOwned++;

            player.PayCash(rentValues[squaresOwned - 1]);
            this.Owner.AddCash(rentValues[squaresOwned - 1]);
        }
    }
}
