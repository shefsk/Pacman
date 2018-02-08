using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PacMan;
using static PacMan.Enumeration;

namespace Pacman.Test
{
    [TestFixture]
    public class CommandTest
    {
        [Test]
        public void InvalidCommandString()
        {
            Command cmd = new Command("TEST");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void ValidCommandString()
        {
            Command cmd = new Command("MOVE");

            Assert.IsTrue(cmd.IsValid);
        }

        [Test]
        public void LowercaseCommandString()
        {
            Command cmd = new Command("left");

            Assert.IsTrue(cmd.IsValid);
        }

        [Test]
        public void PlaceInvalidXCoord()
        {
            Command cmd = new Command("PLACE w,3,NORTH");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void PlaceInvalidYCoord()
        {
            Command cmd = new Command("PLACE 3,T,SOUTH");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void PlaceInvalidDirection()
        {
            Command cmd = new Command("PLACE 1,2,TEST");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void PlaceInvalidDirectionNone()
        {
            Command cmd = new Command("PLACE 1,2,NONE");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void PlaceInvalidStringSpace()
        {
            Command cmd = new Command("PLACE 1, 2, TEST");

            Assert.IsFalse(cmd.IsValid);
        }

        [Test]
        public void PlaceValid()
        {
            Command cmd = new Command("place 1,2,EAST");

            Assert.IsTrue(cmd.IsValid);
            Assert.AreEqual(cmd.X, 1);
            Assert.AreEqual(cmd.Y, 2);
            Assert.AreEqual(cmd.Dir, Direction.EAST);
        }
    }
}
