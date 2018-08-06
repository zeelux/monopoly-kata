using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.BoardClasses
{
    public class BoardSquare
    {
        private string name;

        public BoardSquare()
        {
            this.name = String.Empty;
        }

        public BoardSquare(string name)
        {
            this.name = name;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public virtual bool ApplyEffectOnPass
        {
            get
            {
                return false;
            }
        }

        public virtual void ApplyEffect(Board board, Player player, int roll)
        { 
            
        }
    }
}
