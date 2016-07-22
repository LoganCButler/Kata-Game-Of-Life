using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class GameOfLifeRules
    {
        int[,] GameOfLifeBoard;

        public int[,] RunLifeCycle(int[,] currentboard)
        {
            GameOfLifeBoard = currentboard;
            var boardCoppy = currentboard;
            var nextBoard = currentboard;

            var responce = GetNewCellState(CellState.Alive, getLiveNeighborsNumber(1,1));

            if (responce == CellState.Dead)
            {
                nextBoard[1, 1] = 0;
            }


            return nextBoard;
        }

        private int getLiveNeighborsNumber(int xlocation, int ylocation)
        {
            int liveNeighborCount = 0;

            var north = GameOfLifeBoard[xlocation, ylocation - 1]; //north
            var south = GameOfLifeBoard[xlocation, ylocation + 1]; //south
            var west =  GameOfLifeBoard[xlocation - 1, ylocation]; //West
            var east = GameOfLifeBoard[xlocation + 1, ylocation]; //East

            if (north == 1) { liveNeighborCount += 1; };
            if (south == 1) { liveNeighborCount += 1; };
            if (west == 1) { liveNeighborCount += 1; };
            if (east == 1) { liveNeighborCount += 1; };


            return liveNeighborCount;
        }

        public CellState GetNewCellState(CellState currentState, int liveNeighbors)
        {
            if (currentState == CellState.Alive)
            {
                switch (liveNeighbors)
                {
                    case 2:
                    case 3:
                        return CellState.Alive;
                    default:
                        return CellState.Dead;
                }
            }
            else if (liveNeighbors == 3)
                return CellState.Alive;


            return currentState;
        }



        public enum CellState
        {
            Dead = 0,
            Alive = 1,         
        }
    }
}
