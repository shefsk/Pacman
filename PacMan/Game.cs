using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PacMan.Enumeration;

namespace PacMan
{
    /// <summary>
    /// This class initializes the pacman game simulation. It opens and reads the input file,
    /// executes the commands one by one and builds the output string to display to the user.
    /// </summary>
    
    public class Game
    {
        private List<Command> commands = new List<Command>();
        private List<string> commandStrings = new List<string>();
        private string inputFilePath;
        private string output = string.Empty;
        
        /// <summary>
        /// Gets the output string to display to the end user
        /// </summary>
        public string Output
        {
            get { return output; }
            set
            {
                if (output != value)
                {
                    output = value;
                }
            }
        }

        /// <summary>
        /// Constructor for the Game class
        /// </summary>
        /// <param name="inputPath">The path of the input file</param>
        public Game(string inputPath)
        {
            inputFilePath = inputPath;

            //Check if the input file can be successfully read and file is not empty
            if (readInputFile() && commandStrings.Count > 0)
            {
                parseCommands();
                //Verify that the file contains valid commands 
                if (commands.Count > 0)
                {
                    executeCommands();
                }
                else
                {
                    StringBuilder error = new StringBuilder();
                    error.AppendLine(string.Format("Invalid command format entered. Valid commands include: "));
                    error.AppendLine("PLACE X,Y,F");
                    error.AppendLine("MOVE");
                    error.AppendLine("LEFT");
                    error.AppendLine("RIGHT");
                    error.AppendLine("REPORT");
                    output = error.ToString();
                }             
            }
            else
            {
                output = string.Format("Error opening the input file. Please check the file format and that the file is not empty.");
            }
        }

        /// <summary>
        /// This method located and opens the input file using the 'inputFilePath' variable and
        /// populates the 'commandStrings' list with the commands from the input file.
        /// </summary>
        /// <returns>A bool value of true if the file could be suvccessfully read, else false.</returns>
        private bool readInputFile()
        {
            bool result = false;
            try
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Avoid blank lines if any
                        if (line.Length > 0)
                        {
                            result = true;
                            commandStrings.Add(line);
                        }
                    }                    
                }
            }
            catch(Exception ex)
            {
                result = false;
                throw new Exception("The file could not be read.", ex.InnerException);
            }
            return result;           
        }

        /// <summary>
        /// This method reads through the strings in the 'commandStrings' list 
        /// and parses the strings into valid Command types and adds them into the
        /// 'commands' List
        /// </summary>
        private void parseCommands()
        {            
            foreach (string cstring in commandStrings)
            {
                Command commandHandler = new Command(cstring);           
                if(commandHandler.IsValid)
                {
                    commands.Add(commandHandler);
                }                        
            }
        }

        /// <summary>
        /// This method goes through the 'commands' list and executes each command one by one.
        /// It populates the 'output' sting variable with the result of an action where applicable.
        /// </summary>
        private void executeCommands()
        {
            Actions actions = new Actions();
            StringBuilder result = new StringBuilder();
            foreach (Command command in commands)
            {
                switch (command.CurrentCommand)
                {
                    case CommandSet.Place:
                        string message = string.Empty;
                        if (!actions.Place(command.X, command.Y, command.Dir, out message))
                        {
                            result.AppendLine(message);
                        }          
                        break;
                    case CommandSet.Move:
                        actions.Move();                        
                        break;
                    case CommandSet.Left:
                        actions.Left();       
                        break;
                    case CommandSet.Right:
                        actions.Right();    
                        break;
                    case CommandSet.Report:   
                        result.AppendLine(executeReport(actions));                            
                        break;
                    default:
                        //Ideally this statement will not be reached as this error should be caught sooner in the program.
                        result.AppendLine("Command not recognized."); 
                        break;
                }
            }

            output = result.ToString();
        }

        /// <summary>
        /// Calls the Report command on the Actions class and handles the resulting 
        /// string value.
        /// </summary>
        /// <param name="actions">The Actions object</param>
        /// <returns>The resulting string from executing the REPORT action</returns>
        private string executeReport(Actions actions)
        {
            string result = string.Empty;
            string report = actions.Report();
            if (!String.IsNullOrEmpty(report))
            {
                result = string.Format("OUTPUT: " + report);
            }
            else
            {
                result = string.Format("Invalid command sequence entered.");
            }

            return result;
        }

    }
}
