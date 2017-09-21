using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleLibrary;

namespace TurtleProgram.Tests
{
    [TestClass]
    public class TurtleMoverTests
    {
      
            [TestMethod] 
         public void TurtleMover_InitialisedTurtleMover_ControlsTurtle() 
         { 
             TurtleMover mover = new TurtleMover(new Turtle()); 
             Assert.IsNotNull(mover.Turtle); 
         } 
 
         [TestMethod] 
         public void TurtleMover_EmptyCommand_ReportsInvalid() 
         { 
             TurtleMover mover = new TurtleMover(new Turtle()); 
             string response = mover.Command(""); 
             Assert.AreEqual("Invalid command.", response); 
         } 
 
 
         [TestMethod] 
         public void TurtleMover_UnrecognisedCommand_ReportsInvalid() 
         { 
             TurtleMover mover = new TurtleMover(new Turtle());
             string response = mover.Command("XXXX"); 
             Assert.AreEqual("Invalid command.", response); 
         } 
 
 
         [TestMethod] 
         public void TurtleMover_RecognisedCommand_ReportsValid() 
         {
             TurtleMover mover = new TurtleMover(new Turtle()); 
             string response = mover.Command("MOVE"); 
             Assert.AreEqual("Turtle cannot move until it has been placed on the table.", response); 
         } 
 
 
         [TestMethod] 
         public void TurtleMover_PlaceCommandWithNoArguments_ReportsInvalid() 
         {
             TurtleMover mover = new TurtleMover(new Turtle()); 
             string response = mover.Command("PLACE"); 
             Assert.AreEqual("Invalid command.", response); 
         } 
 
 
         [TestMethod] 
         public void TurtleMover_PlaceCommandWithInvalidArguments_ReportsInvalid() 
         {
             TurtleMover mover = new TurtleMover(new Turtle()); 
             string response = mover.Command("PLACE XXX"); 
             Assert.AreEqual("Invalid command.", response); 
             response = mover.Command("PLACE 1,X,NORTH"); 
             Assert.AreEqual("Invalid command.", response); 
             response = mover.Command("PLACE X,1,NORTH"); 
             Assert.AreEqual("Invalid command.", response); 
             response = mover.Command("PLACE 1,1,XXX"); 
             Assert.AreEqual("Invalid command.", response); 
         } 

 
         [TestMethod] 
         public void TurtleMover_PlacedAndTurnedLeft_ReportsCorrectPosition() 
         {
             TurtleMover mover = new TurtleMover(new Turtle()); 
             mover.Command("PLACE 1,1,NORTH"); 
             mover.Command("LEFT"); 
             Assert.AreEqual("1,1,WEST", mover.Command("REPORT")); 
         } 
 
 
         [TestMethod] 
         public void TurtleMover_PlacedAndTurnedRight_ReportsCorrectPosition() 
         { 
             TurtleMover mover = new TurtleMover(new Turtle()); 
             mover.Command("PLACE 1,1,NORTH"); 
             mover.Command("RIGHT"); 
            Assert.AreEqual("1,1,EAST", mover.Command("REPORT")); 
         } 
 
 
 
        [TestMethod] 
        public void TurtleMover_PlacedAndMoved_ReportsCorrectPosition() 
         { 
             TurtleMover mover = new TurtleMover(new Turtle()); 
             mover.Command("PLACE 1,1,NORTH"); 
             mover.Command("MOVE"); 
             Assert.AreEqual("1,2,NORTH", mover.Command("REPORT")); 
         } 
 
    

        }
    }

