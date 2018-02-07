using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Enumeration;

namespace PacMan
{
    /// <summary>
    /// These four different classes perform the movements for the four different directions that the pacman can move in.
    /// </summary>
    public class North : IMovement
    {
        /// <summary>
        /// Moves the Pacman forward once in the direction it is facing.
        /// </summary>
        /// <param name="x">The current x co-ordinate of the pacman</param>
        /// <param name="y">The current y co-ordinate of the pacman</param>
        /// <returns>A Tuple containing the new x and y co-ordinates of the pacman.</returns>
        public Tuple<int, int> Move(int x, int y)
        {
            return Tuple.Create(x ,y += 1);
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Left(Direction dir)
        {
            return Direction.WEST;
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Right(Direction dir)
        {
            return Direction.EAST;
        }
    }

    public class South : IMovement
    {
        /// <summary>
        /// Moves the Pacman forward once in the direction it is facing.
        /// </summary>
        /// <param name="x">The current x co-ordinate of the pacman</param>
        /// <param name="y">The current y co-ordinate of the pacman</param>
        /// <returns>A Tuple containing the new x and y co-ordinates of the pacman.</returns>
        public Tuple<int, int> Move(int x, int y)
        {
            return Tuple.Create(x, y -= 1);
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Left(Direction dir)
        {
            return Direction.EAST;
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Right(Direction dir)
        {
            return Direction.WEST;
        }
    }

    public class East : IMovement
    {
        /// <summary>
        /// Moves the Pacman forward once in the direction it is facing.
        /// </summary>
        /// <param name="x">The current x co-ordinate of the pacman</param>
        /// <param name="y">The current y co-ordinate of the pacman</param>
        /// <returns>A Tuple containing the new x and y co-ordinates of the pacman.</returns>
        public Tuple<int, int> Move(int x, int y)
        {
            return Tuple.Create(x += 1, y);
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Left(Direction dir)
        {
            return Direction.NORTH;
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Right(Direction dir)
        {
            return Direction.SOUTH;
        }
    }

    public class West : IMovement
    {
        /// <summary>
        /// Moves the Pacman forward once in the direction it is facing.
        /// </summary>
        /// <param name="x">The current x co-ordinate of the pacman</param>
        /// <param name="y">The current y co-ordinate of the pacman</param>
        /// <returns>A Tuple containing the new x and y co-ordinates of the pacman.</returns>
        public Tuple<int, int> Move(int x, int y)
        {
            return Tuple.Create(x -= 1, y);
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Left(Direction dir)
        {
            return Direction.SOUTH;
        }

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        public Direction Right(Direction dir)
        {
            return Direction.NORTH;
        }
    }

    /// <summary>
    /// This class is used to initialize a specific movement class based on a direction.
    /// </summary>
    public static class MovementFactory
    {
        private static Dictionary<Direction, Func<IMovement>> movementMap = new Dictionary<Direction, Func<IMovement>>()
        {
            {Direction.NORTH, () => { return new North(); } },
            {Direction.SOUTH, () => { return new South(); } },
            {Direction.EAST, () => { return new East(); } },
            {Direction.WEST, () => { return new West(); } },
        };

        public static IMovement CreateMovementFromDirection(Direction Dir)
        {     
            movementMap.TryGetValue(Dir, out Func<IMovement> move);

            return move();
        }

        internal static Dictionary<Direction, Func<IMovement>> MovementMap { get => movementMap; set => movementMap = value; }
    }
}
