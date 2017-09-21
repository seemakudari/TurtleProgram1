using System;
using System.Text;

namespace TurtleLibrary
{
   
     public enum Instruction : byte 
     { 
         Invalid = 0, 
         Place = 1, 
         Move = 2, 
         Left = 3, 
         Right = 4, 
         Report = 5, 
    } 
 
 
     public enum Facing : byte 
     { 
         North = 1, 
         East = 2, 
         South = 3, 
         West = 4, 
     } 
 
 
     public enum Direction : int 
     { 
         Left = 1, 
         Right = -1, 
     }

     static class StringConstants
     {
         public const string MOVE = "move", MOVED = "moved", PLACED = "placed", TURN = "turn", REPORT_POSITION = "report it's position";
         public const string EXECUTED = "Executed", INVALID_COMMAND = "Invalid command.";
     }
 }
