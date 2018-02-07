using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static PacMan.Enumeration;

namespace PacMan
{

    /// <summary>
    /// This class initializes a valid command from the given string that is 
    /// read from the input file. It contains information related to a command.
    /// </summary>
    public class Command
    {       
        private CommandSet currentCommand;
        private int xCoordinate = 0;
        private int yCoordinate = 0;
        private Direction dir;
        private Dictionary<string, Direction> directionMap = new Dictionary<string, Direction>()
        {
            { "NORTH", Direction.NORTH },
            {"SOUTH", Direction.SOUTH },
            {"EAST", Direction.EAST },
            { "WEST", Direction.WEST}
        };
        private bool isValid = false;

        public bool IsValid
        {
            get { return isValid; }
            set
            {
                if (isValid != value)
                {
                    isValid = value;
                }
            }
        }

        public Direction Dir
        {
            get { return dir; }
            set
            {
                if (dir != value)
                {
                    dir = value;
                }
            }
        }

        public CommandSet CurrentCommand
        {
            get { return currentCommand; }
            set
            {
                if (currentCommand != value)
                {
                    currentCommand = value;
                }
            }
        }

        public int X
        {
            get
            { return xCoordinate; }
            set
            {
                if (xCoordinate != value)
                {
                    xCoordinate = value;
                }
            }
        }

        public int Y
        {
            get
            { return yCoordinate; }
            set
            {
                if (yCoordinate != value)
                {
                    yCoordinate = value;
                }
            }
        }
       
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="command"> The string value from the input file that is to be parsed into a command.</param>
        public Command(string command)
        {
            isValid = validateAndParseCommand(command);
        }

        /// <summary>
        /// Validates the given string and parses it into a Command
        /// </summary>
        /// <param name="command">The string to validate and parse</param>
        /// <returns>true, if the string is a valid command , else false</returns>
        private bool validateAndParseCommand(string command)
        {
            bool result = false;
            if(!String.IsNullOrEmpty(command))
            {
                string cmd = command.Trim().ToUpper();

                switch (cmd)
                {
                    case "MOVE":
                        result = true;
                        currentCommand = CommandSet.Move;
                        break;
                    case "LEFT":
                        result = true;
                        currentCommand = CommandSet.Left;
                        break;
                    case "RIGHT":
                        result = true;
                        currentCommand = CommandSet.Right;
                        break;
                    case "REPORT":
                        result = true;
                        currentCommand = CommandSet.Report;
                        break;
                    default:
                        result = false;
                        break;
                }

                // Place command requires separate handling since it is not a simple string
                if (!result)
                {
                    result = isPlaceCommand(cmd);
                }

            }

            return result;
        }

        /// <summary>
        /// Parses a string to determine if it matches the format of the PLACE command
        /// and initializes the command if the string is valid.
        /// </summary>
        /// <param name="command">The string to validate and parse</param>
        /// <returns>true, if the string is a valid PLACE command , else false</returns>
        private bool isPlaceCommand(string command)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(command))
            {
                string pattern = @"^[A-Z]\w{4}\s\d\,\d\,[A-Z]{4,5}";

                Regex r = new Regex(pattern);
                Match match = r.Match(command);
                result = match.Success;
                if (result)
                {
                   currentCommand = CommandSet.Place;
                   result = initializePlaceCommand(command);
                }
            }
          
            return result;
        }

        /// <summary>
        /// Initializes the X,Y,F parameters of the PLACE command from a given string.
        /// </summary>
        /// <param name="command">The string to parse</param>
        private bool initializePlaceCommand(string command)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(command))
            {
                string[] parameterSet = command.Split(',');
                //Validate that the array contains the right number of parameters
                if (parameterSet.Length == 3 )
                {                   
                    int x = 0;
                    int y = 0;
                    Direction d = Direction.NONE;
                   
                    if (tryGetX(parameterSet[0], out x))
                    {
                        xCoordinate = x;

                        if (tryGetY(parameterSet[1], out y))
                        {
                            yCoordinate = y;
                           if (tryGetDirection(parameterSet[2], out d))
                            {
                                dir = d;
                                result = true;
                            }
                        }
                    }                                   

                }
            }
            return result;          
        }

        /// <summary>
        ///  Parses the given string in the format "PLACE X" to retrieve the value of the X co-ordinate.
        /// </summary>
        /// <param name="paramStr">The string to parse.</param>
        /// <param name="x">The value of the X co-ordinate</param>
        /// <returns>true, if successful, else false</returns>
        private bool tryGetX(string paramStr, out int x)
        {
            bool result = false;
            x = 0;
            //Get the X parameter value from the 'PLACE X' string
            int startindex = paramStr.Trim().Length - 1;
            if (startindex > 0)
            {
                //Use the startindex above to get the substring with the value of X from the 'PLACE X' string
                string s = paramStr.Substring(startindex, 1);
                int xCoord = 0 ;
                if (!string.IsNullOrEmpty(s) && Int32.TryParse(s, out xCoord))
                {                    
                    x = xCoord;
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Parses the given string in the format "Y" to retrieve the value of the Y co-ordinate.
        /// </summary>
        /// <param name="paramStr">The string to parse.</param>
        /// <param name="y">The value of the Y co-ordinate</param>
        /// <returns>true, if successful, else false</returns>
        private bool tryGetY(string paramStr, out int y)
        {
            bool result = false;
            y = 0;

            int yCoord = 0;
            if (!string.IsNullOrEmpty(paramStr) && Int32.TryParse(paramStr.Trim(), out yCoord))
            {
                y = yCoord;
                result = true;
            }
           
            return result;
        }

        /// <summary>
        /// Parses the given string in the format "F" to retrieve the value of F i.e direction.
        /// </summary>
        /// <param name="paramStr">The string to parse.</param>
        /// <param name="dir">The value of the dir variable</param>
        /// <returns>true, if successful, else false</returns>
        private bool tryGetDirection(string paramStr, out Direction dir)
        {
            bool result = false;
            dir = Direction.NONE;

            if (!string.IsNullOrEmpty(paramStr))
            {
                Direction d;
                if (directionMap.TryGetValue(paramStr.Trim(), out d))
                {
                    dir = d;
                    result = true;
                }               
            }

            return result;
        }
    }
}
