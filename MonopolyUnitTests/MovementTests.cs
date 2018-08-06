using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.BoardClasses;

namespace MonopolyTests
{
    /// <summary>
    /// Summary description for MovementTests
    /// </summary>
    [TestClass]
    public class MovementTests
    {
        [TestMethod]
        public void MovementOfPlayerFromLocation0ToLocation7()
        {
            Player player = new Player("Horse");
            Movement m = new Movement(new Board());
            m.MovePlayer(player, 7);

            Assert.AreEqual(7, player.Location);
        }

        [TestMethod]
        public void MovementOfPlayerPastEndOfBoard()
        {
            Player player = new Player("Horse");
            player.Location = 39;
            Movement m = new Movement(new Board());
            m.MovePlayer(player, 6);

            Assert.AreEqual(5, player.Location);
        }

        [TestMethod]
        public void MovePlayerToLocation_SetsPlayersLocation()
        {
            Player player = new Player("Horse");
            player.Location = 39;
            Movement m = new Movement(new Board());
            m.MovePlayerToLocation(player, 6);

            Assert.AreEqual(6, player.Location);
        }

        [TestMethod]
        public void SendPlayerToJail_SetsLocationAndIsInJail()
        {
            Player player = new Player("Horse");
            player.Location = 39;
            Movement m = new Movement(new Board());
            m.MovePlayerToJail(player);

            Assert.AreEqual(10, player.Location);
            Assert.IsTrue(player.IsInJail);
        }
    }
}
