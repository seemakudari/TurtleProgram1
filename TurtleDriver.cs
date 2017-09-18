using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLibrary
{
    
    /// <summary> 
     /// TurtleDriver class.  Responsible for receiving and parsing commands for the Turtle and passing them on. 
     /// </summary> 
     public class TurtleDriver 
     { 
         public TurtleDriver(Turtle turtle) 
         { 
             this.Turtle = turtle; 
         } 
 
 
         public Turtle Turtle { get; set; } 
 
          public string Command(string command) 
         { 
             string response = "";
             PlaceInstructionArguments args = null; 
             var instruction = GetInstruction(command, ref args); 
 
 
             switch (instruction) 
             { 
                 case Instruction.Place: 
                     var placeArgs = (PlaceInstructionArguments)args; 
                     if (Turtle.Place(placeArgs.X, placeArgs.Y, placeArgs.Facing)) 
                     { 
                         response = "Done."; 
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                    } 
                    break; 
                case Instruction.Move: 
                     if (Turtle.Move()) 
                     { 
                         response = "Done."; 
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                     } 
                     break; 
                 case Instruction.Left: 
                     if (Turtle.Left()) 
                     { 
                         response = "Done."; 
                     } 
                     else 
                     { 
                         response = Turtle.LastError; 
                     } 
                     break; 
                 case Instruction.Right: 
                     if (Turtle.Right()) 
                     { 
                         response = "Done."; 
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
                     response = "Invalid command."; 
                     break; 
             } 
             return response;             
         }


         private Instruction GetInstruction(string command, ref PlaceInstructionArguments args) 
         { 
             Instruction result; 
             string argString = ""; 
 

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


         private bool TryParsePlaceArgs(string argString, ref PlaceInstructionArguments args) 
         { 
             var argParts = argString.Split(',');  
             int x, y; 
             Facing facing; 
 
 
             if (argParts.Length == 3 && 
                 TryGetCoordinate(argParts[0], out x) && 
                 TryGetCoordinate(argParts[1], out y) && 
                 TryGetFacingDirection(argParts[2], out facing)) 
             { 
                 args = new PlaceInstructionArguments 
                 { 
                     X = x, 
                     Y = y, 
                     Facing = facing, 
                 }; 
                 return true; 
             } 
             return false;             
         } 
 
 
         private bool TryGetCoordinate(string coordinate, out int coordinateValue) 
        { 
             return int.TryParse(coordinate, out coordinateValue); 
         } 
 
 
         private bool TryGetFacingDirection(string direction, out Facing facing) 
         { 
             return Enum.TryParse<Facing>(direction, true, out facing); 
         } 
     }     

}
