using System;
using System.Text;
using System.Configuration;

namespace TurtleLibrary
{
    /// <summary> 
     /// Turtle class.  Receives instructions from the mover, validates them and carries them out. 
     /// Maintains internal state for position and facing direction. 
     /// </summary> 
     public class Turtle :ITurtle
     { 
         public Turtle() 
         { 
             LastError = string.Empty; 
         }


         private readonly  int TABLE_SIZE = System.Convert.ToInt32(ConfigurationSettings.AppSettings.Get("TableSize")); 
         private int? _x; 
         private int? _y; 
         private Facing _facing; 
 
 

         public string LastError { get; set; } 
 
         // this method validates if the input position is valid and if it is valid one it places the turtle on the table
         public bool Place(int x, int y, Facing facing) 
         {
             if (CheckIsOnTable(x, y, StringConstants.PLACED)) 
             { 
                 _x = x; 
                 _y = y; 
                 _facing = facing; 
                 return true; 
             } 
             return false; 
         }

         // this method validates if the turtle is plaved and move is valid.if it is valid one it moves the turtle on the table
         public bool Move() 
         {
             if (CheckIsPlaced(StringConstants.MOVE)) 
             { 
                 int newx = GetXAfterMove(); 
                 int newy = GetYAfterMove();
                 if (CheckIsOnTable(newx, newy, StringConstants.MOVED)) 
                 { 
                     _x = newx; 
                     _y = newy; 
                     return true; 
                 }                 
             } 
             return false; 
         }

         // this method gets the value of x cordinate of the tutle after moving the it 
         private int GetXAfterMove() 
         { 
            if (_facing == Facing.East) 
            { 
                 return _x.Value + 1; 
             } 
            else  
             { 
                 if (_facing == Facing.West)  
                 { 
                     return _x.Value - 1; 
                 } 
             } 
             return _x.Value; 
         }

         // this method gets the value of Y cordinate of the tutle after moving the it 
         private int GetYAfterMove() 
         { 
             if (_facing == Facing.North) 
             { 
                 return _y.Value + 1; 
             } 
             else 
             { 
                 if (_facing == Facing.South) 
                 { 
                     return _y.Value - 1; 
                } 
             } 
             return _y.Value; 
        } 
 
         //this method rotates the turtle by 90 degreee towards left 
         public bool Left() 
         { 
             return Turn(Direction.Left); 
         }

         //this method rotates the turtle by 90 degreee towards right 
         public bool Right() 
         { 
             return Turn(Direction.Right); 
         }

         //this method rotates the turtle by 90 degree towards right/left and then changes the face value of turtle 
         private bool Turn(Direction direction) 
         {
             if (CheckIsPlaced(StringConstants.TURN)) 
             { 
                 int facingAsNumber = (int)_facing; 
                 facingAsNumber += 1 * (direction == Direction.Right ? 1 : -1); 
                 if (facingAsNumber == 5) facingAsNumber = 1; 
                if (facingAsNumber == 0) facingAsNumber = 4; 
                 _facing = (Facing)facingAsNumber; 
                 return true; 
             } 
             return false; 
        } 
 
        // this method reports the current position of the turtle
        public string Report() 
         {
             if (CheckIsPlaced(StringConstants.REPORT_POSITION)) 
             { 
                 return String.Format("{0},{1},{2}", _x.Value, _y.Value, _facing.ToString().ToUpper()); 
             } 
             return string.Empty; 
         } 
 
         // this method checks if the turtle has been placed on the table
         private bool CheckIsPlaced(string action) 
         { 
             if (!_x.HasValue || !_y.HasValue) 
             { 
                 LastError = String.Format("Turtle cannot {0} until it has been placed on the table.", action); 
                 return false; 
             } 
             return true; 
         }

         // this method checks if the turtle is not moved out of the table
         private bool CheckIsOnTable(int x, int y, string action) 
         { 
             if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE) 
             { 
                 LastError = String.Format("Turtle cannot be {0} there.", action); 
                 return false; 
             } 
             return true; 
         } 
     } 

}
