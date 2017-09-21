using System;
using System.Text;

namespace TurtleLibrary
{
    
    /// <summary> 
     /// TurtleDriver class.  Responsible for receiving and parsing commands for the Turtle and passing them on. 
     /// </summary> 
     public class TurtleMover 
     { 
         public TurtleMover(Turtle turtle) 
         { 
             this.Turtle = turtle; 
         } 
 
 
         public Turtle Turtle { get; set; } 
 
         //this method takes the input command  validates  and if it is a valid one then executes it otherwise returns the appropriate error message.
          public string Command(string command) 
         { 
             string response = string.Empty;
             Position args = null;
             Instruction instruction = GetInstruction(command, ref args); 
 
 
             switch (instruction) 
             { 
                 case Instruction.Place:
                     Position placeArgs = (Position)args; 
                     if (Turtle.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing)) 
                     {
                         response = StringConstants.EXECUTED; 
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                    } 
                    break; 
                case Instruction.Move: 
                     if (Turtle.Move()) 
                     {
                         response = StringConstants.EXECUTED;
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                     } 
                     break; 
                 case Instruction.Left: 
                     if (Turtle.Left()) 
                     {
                         response = StringConstants.EXECUTED;
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                     } 
                     break; 
                 case Instruction.Right: 
                     if (Turtle.Right()) 
                     {
                         response = StringConstants.EXECUTED; 
                     } 
                     else 
                    { 
                         response = Turtle.LastError; 
                     } 
                     break; 
                case Instruction.Report: 
                     response = Turtle.Report(); 
                     break; 
                 default:
                     response = StringConstants.INVALID_COMMAND;
                     break; 
             } 
             return response;             
         }

          // this method parses the input command checks if it is a Place command if yes  then calls TryParsePlaceArgs to initialize the position of the turtle instance
         private Instruction GetInstruction(string command, ref Position args) 
         { 
             Instruction result; 
             string argString = string.Empty; 
 

             int argsSeperatorPosition = command.IndexOf(" "); 
             if (argsSeperatorPosition > 0) 
             { 
                 argString = command.Substring(argsSeperatorPosition + 1); 
                 command = command.Substring(0, argsSeperatorPosition); 
             } 
             command = command.ToUpper(); 
 
 
             if (Enum.TryParse<Instruction>(command, true, out result)) 
             { 
                 if (result == Instruction.Place) 
                 { 
                     if (!TryParsePlaceArgs(argString, ref args)) 
                     { 
                         result = Instruction.Invalid; 
                     } 
                 } 
             } 
             else 
             { 
                 result = Instruction.Invalid; 
             } 
             return result; 
        }

         //this method  initializes the position of the turtle instance
         private bool TryParsePlaceArgs(string argString, ref Position args) 
         { 
             string[] argParts = argString.Split(',');  
             int x, y; 
             Facing facing; 
 
 
             if (argParts.Length == 3 && 
                 TryGetCoordinate(argParts[0], out x) && 
                 TryGetCoordinate(argParts[1], out y) && 
                 TryGetFacingDirection(argParts[2], out facing)) 
             { 
                 args = new Position 
                 { 
                     X = x, 
                     Y = y, 
                     Facing = facing, 
                 }; 
                 return true; 
             } 
             return false;             
         }

         //this method  initializes the x/ y co-ordinate of the turtle instance
         private bool TryGetCoordinate(string coordinate, out int coordinateValue) 
        { 
             return int.TryParse(coordinate, out coordinateValue); 
         }

         //this method  initializes the facing direction of the turtle instance
         private bool TryGetFacingDirection(string direction, out Facing facing) 
         { 
             return Enum.TryParse<Facing>(direction, true, out facing); 
         } 
     }     

}
