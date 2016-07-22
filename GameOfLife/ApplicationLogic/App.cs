using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class GameOfLifeRules
    {
       // int[,] GameOfLifeBoard;
        int maxBoardValue = 2;

        public int[,] RunLifeCycle(int[,] currentboard)
        {
            int[,] nextBoard = new int[3,3];

            for(var Row = 0; Row <= maxBoardValue; Row++)
            {
                for(var Col = 0; Col <= maxBoardValue; Col++)
                {
                    CellState currentCellState = (CellState)currentboard[Row, Col];
                    var responce = GetNewCellState(currentCellState, getLiveNeighborsNumber(Row, Col, currentboard));

                    if (responce == CellState.Dead)
                    {
                        nextBoard[Row, Col] = 0;
                    }
                    if (responce == CellState.Alive)
                    {
                        nextBoard[Row, Col] = 1;
                    }
                }
            }

            return nextBoard;
        }

        

        private int getLiveNeighborsNumber(int row, int col, int[,] board)
        {
            int liveNeighborCount = 0;
            int north=0; int south=0; int east=0;  int west=0;

            if (0 < row)
            {
                north = board[row -1, col]; //north
            }
            if (row < maxBoardValue)
            { 
                south = board[row + 1, col]; //south 
            }
            if (0 < col)
            {
                west = board[row, col -1]; //West
            }
            if (col < maxBoardValue)
            {
                east = board[row, col +1]; //East 
            }

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
            {
                return CellState.Alive;
            }
                


            return currentState;
        }



        public enum CellState
        {
            Dead = 0,
            Alive = 1,         
        }


        public string PrintGameBoard(int[,] board)
        {
            var columnLength = board.GetLength(0);
            var rowLength = board.GetLength(1);
            string boardString="";

            for (var Row = 0; Row <= maxBoardValue; Row++)
            {
                for (var Col = 0; Col <= maxBoardValue; Col++)
                {
                    int cellValue = board[Row, Col];   

                    if (cellValue == 1)
                    {
                        boardString += "X";
                    }
                    if (cellValue == 0)
                    {
                        boardString += " ";
                    }
                }
                boardString += "\n";
            }
            return boardString;
        }
    }

   
}
