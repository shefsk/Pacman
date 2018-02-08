using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{

    /// <summary>
    /// This class contains all the enums used in the application.
    /// </summary>
    public class Enumeration
    {
        public enum Direction
        {
            NORTH = 1,
            SOUTH = 2,
            EAST = 3,
            WEST = 4,
            NONE = 5
        }

        public enum CommandSet
        {
            Place = 1,
            Move = 2,
            Left = 3,
            Right = 4,
            Report = 5
        }
    }
}
