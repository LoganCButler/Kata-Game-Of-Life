﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class GameOfLifeRules
    {
       public  int boardDimention = 10;
        public int maxBoardIndexValue = 9;

        public int[,] CreateRandomSeed()
        {
            
            int[,] freshBoard = new int[boardDimention, boardDimention];

            for (var Row = 0; Row <= maxBoardIndexValue; Row++)
            {
                for (var Col = 0; Col <= maxBoardIndexValue; Col++)
                {
                    Random r = new Random();
                    int number = r.Next(2);
                    freshBoard[Row, Col] = number;
                    int milliseconds = 10;
                    Thread.Sleep(milliseconds);
                }
            }


            return freshBoard;
        }
        

        public int[,] RunLifeCycle(int[,] currentboard)
        {
            int[,] nextBoard = new int[boardDimention,boardDimention];

            for(var Row = 0; Row <= maxBoardIndexValue; Row++)
            {
                for(var Col = 0; Col <= maxBoardIndexValue; Col++)
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
            int northWest=0; int northEast=0; int southWest=0; int southEast = 0;

            if (0 < row)
            {
                north = board[row -1, col]; //north
            }
            if (0 < col)
            {
                west = board[row, col - 1]; //West
            }
            if (row < maxBoardIndexValue)
            { 
                south = board[row + 1, col]; //south 
            }
            
            if (col < maxBoardIndexValue)
            {
                east = board[row, col +1]; //East 
            }


            if (0 < row && 0 < col)
            {
                northWest = board[row - 1, col - 1]; //north West
            }
            if (0 < row && col < maxBoardIndexValue)
            {
                northEast = board[row - 1, col + 1]; //north East
            }
            if (row < maxBoardIndexValue && 0 < col)
            {
                southWest = board[row + 1, col - 1]; //South West
            }
            if (row < maxBoardIndexValue && col < maxBoardIndexValue)
            {
                southEast = board[row + 1, col + 1]; //South East
            }

            if (north == 1) { liveNeighborCount += 1; };
            if (south == 1) { liveNeighborCount += 1; };
            if (west == 1) { liveNeighborCount += 1; };
            if (east == 1) { liveNeighborCount += 1; };

            if (northEast == 1) { liveNeighborCount += 1; };
            if (northWest == 1) { liveNeighborCount += 1; };
            if (southEast == 1) { liveNeighborCount += 1; };
            if (southWest == 1) { liveNeighborCount += 1; };


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
            string boardString= "---------------------------------------------\n";

            for (var Row = 0; Row <= maxBoardIndexValue; Row++)
            {
                for (var Col = 0; Col <= maxBoardIndexValue; Col++)
                {
                    int cellValue = board[Row, Col];   

                    if (cellValue == 1)
                    {
                        boardString += " X |";
                    }
                    if (cellValue == 0)
                    {
                        boardString += "   |";
                    }
                }
                boardString += "\n---------------------------------------------\n";
            }
            return boardString;
        }
    }

   
}
