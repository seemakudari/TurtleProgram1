using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;

namespace TurtleProgram.Tests
{
    /// <summary>
    /// Summary description for TurtleTest
    /// </summary>
    [TestClass]
    public class TurtleTest
    {
        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotBeMoved()
        {
            Turtle turtle = new Turtle();
            bool result = turtle.Move();
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot move until it has been placed on the table.", turtle.LastError);
        }


        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotBeTurned()
        {
            Turtle turtle = new Turtle();
            bool result = turtle.Left();
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot turn until it has been placed on the table.", turtle.LastError);
        }


        [TestMethod]
        public void Turtle_InitialisedButNotPlaced_CannotReportItsPosition()
        {
            Turtle turtle = new Turtle();
            string result = turtle.Report();
            Assert.AreEqual("", result);
            Assert.AreEqual("Turtle cannot report it's position until it has been placed on the table.", turtle.LastError);
        }


        [TestMethod]
        public void Turtle_PlacedOffTable_CannotBePlaced()
        {
            Turtle turtle = new Turtle();
            bool result = turtle.Place(-1, 0, Facing.North);
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot be placed there.", turtle.LastError);


            result = turtle.Place(0, 6, Facing.North);
            Assert.IsFalse(result);
            Assert.AreEqual("Turtle cannot be placed there.", turtle.LastError);
        }


        [TestMethod]
        public void Turtle_Placed_CanReportItsPosition()
        {
            Turtle turtle = new Turtle();
            bool result = turtle.Place(3, 2, Facing.East);
            string position = turtle.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("", turtle.LastError);
            Assert.AreEqual("3,2,EAST", position);
        }


        [TestMethod]
        public void Turtle_PlacedAndTurnedLeft_ReportsCorrectPosition()
        {
            Turtle turtle = new Turtle();
            turtle.Place(1, 1, Facing.North);
            turtle.Left();
            Assert.AreEqual("1,1,WEST", turtle.Report());
        }


        [TestMethod]
        public void Turtle_PlacedAndTurnedRight_ReportsCorrectPosition()
        {
            Turtle turtle = new Turtle();
            turtle.Place(1, 1, Facing.North);
            turtle.Right();
            Assert.AreEqual("1,1,EAST", turtle.Report());
        }


       

        [TestMethod]
        public void Turtle_PlacedAndMoved_ReportsCorrectPosition()
        {
            Turtle turtle = new Turtle();
            turtle.Place(1, 1, Facing.North);
            turtle.Move();
            Assert.AreEqual("1,2,NORTH", turtle.Report());
        }

    } 

}
