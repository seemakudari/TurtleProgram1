using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLibrary
{
    interface ITurtle
    {
         bool Place(int x, int y, Facing facing);
         bool Move();
         bool Left();
         bool Right();
         string Report();
    }
}
