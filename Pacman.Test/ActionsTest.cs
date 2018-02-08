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
    public class ActionsTest
    {
        #region Place Tests

        [Test]
        public void ValidPlaceCoordinates()
        {
            Actions action = new Actions();
            string error= string.Empty;
            bool result = action.Place(1,2,Direction.NORTH, out error);

            Assert.IsTrue(result);
            Assert.IsEmpty(error);
        }

        [Test]
        public void InValidPlaceCoordinates()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(5, 5, Direction.NORTH, out error);

            Assert.IsFalse(result);
            Assert.IsNotEmpty(error);
        }

        [Test]
        public void NegativePlaceCoordinates()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(-1, -2, Direction.NORTH, out error);

            Assert.IsFalse(result);
            Assert.IsNotEmpty(error);
        }

        [Test]
        public void InvalidDirectionParameter()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NONE, out error);

            Assert.IsFalse(result);
            Assert.IsNotEmpty(error);
        }
        #endregion

        #region Move Tests
        [Test]
        public void InvalidWithoutPlaceFirst()
        {
            Actions action = new Actions();
     
            action.Move();

            Assert.IsFalse(action.IsValidCommand);           
        }

        [Test]
        public void ValidWithPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NORTH, out error);
            action.Move();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 3);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.NORTH);
        }

        [Test]
        public void InValidWithMoveOutsideGridNorth()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 3, Direction.NORTH, out error);
            action.Move();
            action.Move();
           
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 4); 
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.NORTH);
        }

        [Test]
        public void InValidWithMoveOutsideGridSouth()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.SOUTH, out error);
            action.Move();
            action.Move();
            action.Move();

            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 0); 
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.SOUTH);
        }

        [Test]
        public void InValidWithMoveOutsideGridEast()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(3, 3, Direction.EAST, out error);
            action.Move();
            action.Move();

            Assert.AreEqual(action.CurrentPosition.X, 4);
            Assert.AreEqual(action.CurrentPosition.Y, 3);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.EAST);
        }

        [Test]
        public void InValidWithMoveOutsideGridWest()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 3, Direction.WEST, out error);
            action.Move();
            action.Move();

            Assert.AreEqual(action.CurrentPosition.X, 0);
            Assert.AreEqual(action.CurrentPosition.Y, 3); 
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.WEST);
        }
        #endregion

        #region Left Tests

        [Test]
        public void InvalidLeftWithoutPlaceFirst()
        {
            Actions action = new Actions();

            action.Left();

            Assert.IsFalse(action.IsValidCommand);
        }

        [Test]
        public void ValidLeftWithPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NORTH, out error);
            action.Left();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.WEST);
        }

        [Test]
        public void InvalidLeftWithInvalidPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NONE, out error);
            action.Left();

            Assert.IsFalse(action.IsValidCommand);         
        }

        [Test]
        public void LeftWithDirSouth()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.SOUTH, out error);
            action.Left();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.EAST);
        }

        [Test]
        public void LeftWithDirEast()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.EAST, out error);
            action.Left();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.NORTH);
        }

        [Test]
        public void LeftWithDirWest()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.WEST, out error);
            action.Left();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.SOUTH);
        }

        #endregion

        #region Right Tests

        [Test]
        public void InvalidRightWithoutPlaceFirst()
        {
            Actions action = new Actions();

            action.Right();

            Assert.IsFalse(action.IsValidCommand);
        }

        [Test]
        public void ValidRightWithPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NORTH, out error);
            action.Right();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.EAST);
        }

        [Test]
        public void InvalidRightWithInvalidPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.NONE, out error);
            action.Right();

            Assert.IsFalse(action.IsValidCommand);

        }

        [Test]
        public void RightWithDirSouth()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.SOUTH, out error);
            action.Right();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.WEST);
        }

        [Test]
        public void RightWithDirEast()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.EAST, out error);
            action.Right();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.SOUTH);

        }

        [Test]
        public void RightWithDirWest()
        {
            Actions action = new Actions();
            string error = string.Empty;
            bool result = action.Place(1, 2, Direction.WEST, out error);
            action.Right();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.NORTH);
        }

        #endregion

        #region Report Tests

        [Test]
        public void InvalidReportWithoutPlaceFirst()
        {
            Actions action = new Actions();
            string output = string.Empty;
            output = action.Report();

            Assert.IsFalse(action.IsValidCommand);
            Assert.IsEmpty(output);
        }

        [Test]
        public void ValidReportWithPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            string output = string.Empty;
            bool result = action.Place(1, 2, Direction.NORTH, out error);
            output = action.Report();

            Assert.IsTrue(action.IsValidCommand);
            Assert.AreEqual(action.CurrentPosition.X, 1);
            Assert.AreEqual(action.CurrentPosition.Y, 2);
            Assert.AreEqual(action.CurrentPosition.Dir, Direction.NORTH);
            Assert.IsNotEmpty(output);
        }

        [Test]
        public void InvalidReportWithInvalidPlaceFirst()
        {
            Actions action = new Actions();
            string error = string.Empty;
            string output = string.Empty;
            bool result = action.Place(1, 2, Direction.NONE, out error);
            output = action.Report(); 

            Assert.IsFalse(action.IsValidCommand);
            Assert.IsEmpty(output);
        }

        #endregion
    }
}
