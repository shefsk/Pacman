using static PacMan.Enumeration;

namespace PacMan
{
    /// <summary>
    /// This class contains the PacmanPosition struct which is used to store information about the 
    /// current position of pacman.
    /// </summary>
    public partial class Actions
    {
        public struct PacmanPosition {
            private int x;
            private int y;
            private Direction dir;

            /// <summary>
            /// Gets the x co-ordinate 
            /// </summary>
            public int X {
                get
                { return x; }
                set
                {
                    if (x != value)
                    {
                        x = value;
                    }
                }
            }

            /// <summary>
            /// Gets the y co-ordinate 
            /// </summary>
            public int Y
            {
                get
                { return y; }
                set
                {
                    if (y != value)
                    {
                        y = value;
                    }
                }
            }

            /// <summary>
            /// Gets the direction 
            /// </summary>
            public Direction Dir
            {
                get
                { return dir; }
                set
                {
                    if (dir != value)
                    {
                        dir = value;
                    }
                }
            }

        };
    }
}
