# Pacman
Pacman simulation coding problem

Summary:
The Pacman application simulates moving a pacman on a 5 x 5 grid. The available commands to perform movement are 
PLACE X,Y,F

MOVE

LEFT

RIGHT

REPORT

Assumptions:

Origin (0,0) is to considered the SOUTH WEST most corner.

The first valid command to a pacman is the PLACE command. Any other commands before this are ignored.


I chose C# for my implementation as that is the language that I felt I sould easily use to implement as well as
Unit test the application. 
I created a small windows forms application that takes in the input and displays the output.The input is expected 
to be a text file with the commands written on separate lines. The commands can be uppercase or lowercase. 

The application consists of the Game class, which essentianlly performs the simulation. It takes care of opening 
and reading the input file and builds the output string to display the result of the simulation to the user.

Once the input file is read, the Game class uses the Commands class to validate and parse the string commands into a list
of Command objects. The Command object has knowledge of the type of command, validity, the direction and X, Y co-ordinates.

After the commands are parsed, the Game class goes through the list of commands and uses the Action class to perform the
action on the grid as specified by each command. The action class keep track of the pacman's position after every move and
is also responsible for making sure that an action does not move the pacman off the grid. The Movement class was added to 
simplify the code by letting the pacman determine its movement based on its current direction. 

I also added some additional error messages to the code:
1) When the user performs an invalid PLACE command, they see an error message informing them of the expected X, Y range.
2) When a file of invalid commands is uploaded , the user is prompted with a messsage giving them a list of valid commands.
3) When a REPORT is performed on an invalid set of commands e.g REPORT as the first command of the input file, 
the user sees a message informing them of the invalid command instead of ablank line.
