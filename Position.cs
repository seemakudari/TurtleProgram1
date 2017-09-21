using System;
using System.Text;

namespace TurtleLibrary
{
    /// <summary> 
    /// Maintains internal state for position and facing direction. 
    /// </summary>
    public class Position  
    { 
         public int X { get; set; } 
         public int Y { get; set; } 
         public Facing Facing { get; set; } 
     } 

}
