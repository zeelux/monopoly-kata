using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class PropertySquare : OwnableSquare
    {
        public PropertySquare() : base()
        {
        }

        public PropertySquare(string name, int price, PropertyGroup propertyGroup, int[] rentValues) : base(name, price, propertyGroup)
        {
            this.rentValues = rentValues;
        }

        private int[] rentValues;
        private int numberOfStructures;

        public override void ApplyEffect(Board board, Player player, int roll)
        {
            if (this.Owner == null || this.Owner == player || this.Mortgaged)
                return;

            int rentAmount = CalculateRent(board);

            player.PayCash(rentAmount);
            this.Owner.AddCash(rentAmount);
        }

        private int CalculateRent(Board board)
        {
            int rentAmount = this.rentValues[this.numberOfStructures];
            bool allPropertiesInGroupOwned = AreAllPropertiesInGroupOwned(board);

            if (this.numberOfStructures == 0 && allPropertiesInGroupOwned)
                rentAmount *= 2;

            return rentAmount;
        }
        
        public void AddStructure()
        {
            numberOfStructures++;
        }        
    }
}