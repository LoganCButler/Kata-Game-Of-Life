using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogic;

namespace UnitTest
{
    [TestClass]
    public class NeighborTest
    {
        [TestMethod]
        public void NoNeighbors()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 0, 0 }, {0,1,0 }, {0,0,0 } };

            //Act

            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            Assert.AreEqual(expectedEndBoard[1,1], answer[1,1]);
        }
    }

    [TestClass]
    public class GameOfLifeCellStateRules
    {      
        [TestMethod]
        public void FewerThanAlive2Dies() //Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();          
            var currentState = GameOfLifeRules.CellState.Alive;
            int liveNeighbors = 1; // underpopulated value

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Dead, result); //Assert that cell dies appropiatly 
        }


        [TestMethod]
        public void CellLivesWith2() // Any live cell with two live neighbours lives on to the next generation.
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            var currentState = GameOfLifeRules.CellState.Alive;
            int liveNeighbors = 2; // stable Population value

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Alive, result); //Assert that lives 
        }


        [TestMethod]
        public void CellLivesWith3() // Any live cell with three live neighbours lives on to the next generation.
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            var currentState = GameOfLifeRules.CellState.Alive;
            int liveNeighbors = 3; // stable Population value

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Alive, result); //Assert that lives 
        }

        [TestMethod]
        public void CellLivesWiteMoreThan3() // Any live cell with more than three live neighbours dies, as if by over-population.
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            var currentState = GameOfLifeRules.CellState.Alive;
            int liveNeighbors = 5; // over Population value

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Dead, result); //Assert that Dies 
        }

        [TestMethod]
        public void CellBornWithe3() // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            var currentState = GameOfLifeRules.CellState.Dead;
            int liveNeighbors = 3; // Reproduction

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Alive, result); //Assert that Cell is born 
        }

        [TestMethod]
        public void CellDeadStaysDead() //Dead and stays dead
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            var currentState = GameOfLifeRules.CellState.Dead;
            int liveNeighbors = 4; // stays dead

            //Act
            var result = GameOfLife.GetNewCellState(currentState, liveNeighbors);

            //Assert
            Assert.AreEqual(GameOfLifeRules.CellState.Dead, result); //Assert that Cell is dead 
        }






    }
}
