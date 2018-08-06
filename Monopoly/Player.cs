using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.BoardClasses;

namespace Monopoly
{
    public class Player : IComparable<Player>
    {
        private string name;
        private int location;

        public int Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Player(string name)
        {
            this.name = name;
            Initialize();
        }

        public int CompareTo(Player other)
        {
            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return this.name;
        }

        private int cashOnHand;
        public int CashOnHand { 
            get { 
                return this.cashOnHand; 
            } 
        }

        public void AddCash(int value)
        {
            this.cashOnHand += value;
        }

        public void PayCash(int value)
        {
            this.cashOnHand -= value;
        }

        public int TotalWorth { get { return this.cashOnHand; } }

        internal void Initialize()
        {
            this.location = 0;
            this.cashOnHand = 0;
            this.IsInJail = false;
            this.TurnsInJail = 0;
        }

        public void BuyProperty(PropertySquare propertySquare)
        {
            if (this.cashOnHand >= propertySquare.Price)
            {
                propertySquare.Owner = this;
                this.cashOnHand -= propertySquare.Price;
            }
        }

        public void BuyMyWayOutOfJail()
        {
            if (IsInJail)
            {
                PayCash(50);
                IsInJail = false;
            }
        }

        public bool IsInJail { get; set; }

        public int TurnsInJail { get; set; }
    }
}
