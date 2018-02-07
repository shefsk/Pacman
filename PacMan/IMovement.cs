using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Enumeration;

namespace PacMan
{
    /// <summary>
    /// This interface is implamented by the movement class to determine the movements for the four different directions.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Moves the Pacman forward once in the direction it is facing.
        /// </summary>
        /// <param name="x">The current x co-ordinate of the pacman</param>
        /// <param name="y">The current y co-ordinate of the pacman</param>
        /// <returns>A Tuple containing the new x and y co-ordinates of the pacman.</returns>
        Tuple<int,int> Move(int x, int y);

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        Direction Left(Direction dir);

        /// <summary>
        ///  Rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        /// <param name="dir">The current direction of the pacman</param>
        /// <returns>The new direction that the pacman is facing</returns>
        Direction Right(Direction dir);
    }
}
