using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class OwnableSquare : BoardSquare
    {
        public OwnableSquare() : base()
        {
            this.price = 0;
        }

        public OwnableSquare(string name, int price, PropertyGroup propertyGroup)
            : base(name)
        {
            this.price = price;
            this.group = propertyGroup;
            this.mortgaged = false;
        }

        protected bool AreAllPropertiesInGroupOwned(Board board)
        {
            bool allPropertiesInGroupOwned = true;
            List<BoardSquare> groupProperties = board.GetAllBoardSquaresInGroup(this.Group);
            foreach (BoardSquare property in groupProperties)
                if (((PropertySquare)property).Owner == null)
                    allPropertiesInGroupOwned = false;
            
            return allPropertiesInGroupOwned;
        }

        private int price;
        private Player owner;
        private PropertyGroup group;
        private bool mortgaged; 

        public PropertyGroup Group
        {
            get { return group; }
            set { group = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Player Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public bool Mortgaged 
        {
            get { return this.mortgaged; }
            set { this.mortgaged = value; }
        }

        public enum PropertyGroup
        {
            Purple,
            Light_Blue,
            Light_Purple,
            Orange,
            Red,
            Yellow,
            Green,
            Dark_Blue,
            Railroad,
            Utility
        }


    }
}
