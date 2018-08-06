using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.BoardClasses;

namespace Monopoly
{
    public class Movement
    {
        private Board board;

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }

        public Movement(Board board)
        {
            this.board = board;
        }

        public void MovePlayer(Player player, int spacesToMove)
        {
            for (int spacesMoved = 1; spacesMoved <= spacesToMove; spacesMoved++)
            {
                if (player.Location + 1 >= board.NumberOfSquares)
                    player.Location = 0;
                else
                    player.Location++;

                if (board.GetSquareAtPosition(player.Location).ApplyEffectOnPass)
                    board.GetSquareAtPosition(player.Location).ApplyEffect(board, player, spacesToMove);
            }
        }

        public void MovePlayerToLocation(Player player, int location)
        {
            player.Location = location;
        }

        public void MovePlayerToJail(Player player)
        {
            player.Location = 10;
            player.IsInJail = true;
        }
    }
}
