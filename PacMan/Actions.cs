using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Enumeration;

namespace PacMan
{

    /// <summary>
    /// This class performs the given action commands on the grid. It checks if the given command
    /// can be performed without going off the grid before proceeding with the action. 
    /// Assumptions/ Conditions:
    /// -- The first valid command to Pacman is a PLACE command. All commands before this are discarded
    /// </summary>
    public partial class Actions
    {
        private bool isValidCommand = false;
        private static int gridSize = 5;
        private static int maxGridPosition = gridSize - 1;             
        private PacmanPosition currentPosition;

        /// <summary>
        /// Gets the current position and direction of pacman
        /// </summary>
        public PacmanPosition CurrentPosition
        {
            get { return currentPosition; }              
        }

        /// <summary>
        /// This value is True when a valid PLACE command has been executed first , else false
        /// </summary>
        public bool IsValidCommand
        {
            get { return isValidCommand; }
        }

        public Actions()
        {
            currentPosition = new PacmanPosition();
        }

        /// <summary>
        /// This method puts the pacman in the grid in the x, y position facing the direction specified.
        /// If the position is invalid , it returns a false and displays an error message to the user but
        /// continues with the execution.
        /// Assumption: (0,0) is the south west corner of the grid
        /// </summary>
        /// <param name="X">x co-ordinate of the pacman</param>
        /// <param name="Y">y co-ordinate of the pacman</param>
        /// <param name="Direction">direction of the pacman</param>
        /// <param name="error"> error message displayed ot the user if the co-ordinates move the pacman off the grid.</param>
        /// <returns>true , if the x, y co-ordinates are within the grid, else false</returns>
        public bool Place(int X, int Y, Direction Direction, out string error)
        {           
            bool result = false;

            //Check if x and Y co-ordinates are valid, perform command only if valid else ignore        
            if (isValidCoordinate(X) && isValidCoordinate(Y) && Direction != Direction.NONE)
            {
                isValidCommand = true;
                result = true;
                error = string.Empty;
                currentPosition.X = X;
                currentPosition.Y = Y; 
                currentPosition.Dir = Direction;
            }
            else
            {
               
                result = false;
                //error message for invalid x/y co-ordinates
                error = String.Format("Invalid Place Command:PLACE {0},{1},{2}. X and Y coordinates should be between 0 and {3}", X,Y,Direction.ToString(), maxGridPosition);
                
            }

            return result;
        }

        /// <summary>
        /// Checks if the given x/y co-ordinate is valid and within bounds of the array.
        /// </summary>
        /// <param name="coordinate">th ex/y co-ordinate</param>
        /// <returns>true if the co-ordinates are correct , false otherwise.</returns>
        private bool isValidCoordinate(int coordinate)
        {
            return (coordinate >= 0 && coordinate <= maxGridPosition);
        }

        /// <summary>
        /// This method moves the Pacman forward once in the direction it is facing
        /// </summary>
        public void Move()
        {
            //if command is valid i.e a place command was performaed before this, move forward once
            if(isValidCommand && isValidMove())
            {
                //create Movement
                IMovement movement = MovementFactory.CreateMovementFromDirection(currentPosition.Dir);
                //perform move.
                Tuple<int,int> newPosition = movement.Move(currentPosition.X, currentPosition.Y);
                //update x and y co-ordinates
                currentPosition.X = newPosition.Item1;
                currentPosition.Y = newPosition.Item2;

            }           
        }

        /// <summary>
        /// Validates that the current move will not move the pacman off the grid.
        /// </summary>
        /// <returns>true , if the current move is valid, false otherwise.</returns>
        private bool isValidMove()
        {
            bool result = false;

            switch (currentPosition.Dir)
            {
                case Direction.NORTH:                    
                    result = currentPosition.Y < maxGridPosition;
                    break;
                case Direction.SOUTH:
                    result = currentPosition.Y > 0; 
                    break;
                case Direction.EAST:
                    result = currentPosition.X < maxGridPosition;
                    break;
                case Direction.WEST:
                    result = currentPosition.X > 0;
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        ///  This method rotates the Pacman 90 degrees to the left without changing the position
        /// </summary>
        public void Left()
        {
            if(isValidCommand)
            {
                IMovement movement = MovementFactory.CreateMovementFromDirection(currentPosition.Dir);
                currentPosition.Dir =  movement.Left(currentPosition.Dir);
            }           
        }

        /// <summary>
        ///  This method rotates the Pacman 90 degrees to the right without changing the position
        /// </summary>
        public void Right()
        {
            if (isValidCommand)
            {
                IMovement movement = MovementFactory.CreateMovementFromDirection(currentPosition.Dir);
                currentPosition.Dir = movement.Right(currentPosition.Dir);
            }
            
        }

        /// <summary>
        /// This method announces the X,Y position and direction of the pacman. 
        /// </summary>
        /// <returns>Output string containing the current position of pacman.</returns>
        public string Report()
        {
            string result = string.Empty;
            if (isValidCommand)
            {
                string direction = currentPosition.Dir.ToString();
                result = String.Format(" {0}, {1}, {2}", currentPosition.X.ToString(), currentPosition.Y.ToString(), direction);
            }           
                     
            return result;
        }
    }
}
