using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogic;

namespace ConwayGoLTest
{
    [TestClass]
    public class FullBoardTest
    {
        [TestMethod]
        public void EveryoneLivesAndOneIsBorn()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 0 } };

            //Act
            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 0, 0 }, { 1, 1, 0 }, { 1, 1, 0 } };
            var areEqual = CheckForEqualBoards(answer, expectedEndBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void OnlyCornersLive()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            //Act
            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 1, 0, 1 }, { 0, 0, 0 }, { 1, 0, 1 } };
            var areEqual = CheckForEqualBoards(answer, expectedEndBoard);
            Assert.IsTrue(areEqual);
        }
        [TestMethod]
        public void LiveBornAndDie()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 1, 1 }, { 0, 0, 1 }, { 0, 1, 0 } };

            //Act
            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } };
            var areEqual = CheckForEqualBoards(answer, expectedEndBoard);
            Assert.IsTrue(areEqual);
        }

        public bool CheckForEqualBoards(int[,] answer, int[,] expectedEndBoard)
        {
            var areEqual = true;

            for (var Row = 0; Row <= 2; Row++)
            {
                for (var Col = 0; Col <= 2; Col++)
                {
                    if (answer[Row,Col] != expectedEndBoard[Row, Col])
                    {
                        areEqual = false;
                    }
                }
            }

            return areEqual;
        }
    }

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

        [TestMethod]
        public void TwoNeighbors()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };

            //Act

            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
            Assert.AreEqual(expectedEndBoard[1, 1], answer[1, 1]);
        }

        [TestMethod]
        public void BornWithThreeNeighbors()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };

            //Act

            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
            Assert.AreEqual(expectedEndBoard[1, 1], answer[1, 1]);
        }

        [TestMethod]
        public void FourNeighborsNoChange()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };

            //Act

            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            Assert.AreEqual(expectedEndBoard[1, 1], answer[1, 1]);
        }
        [TestMethod]
        public void FourNeighborsDie()
        {
            //Arrange
            GameOfLifeRules GameOfLife = new GameOfLifeRules();
            int[,] currentboard = { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };

            //Act

            var answer = GameOfLife.RunLifeCycle(currentboard);

            //Assert
            int[,] expectedEndBoard = { { 0, 1, 0 }, { 1, 0, 1 }, { 0, 1, 0 } };
            Assert.AreEqual(expectedEndBoard[1, 1], answer[1, 1]);
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
