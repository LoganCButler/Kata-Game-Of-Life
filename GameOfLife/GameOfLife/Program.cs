using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogic;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] board = { { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 1, 0,1,0,1,0,0,1},
            //                { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 1, 0,1,0,1,0,0,1},
            //                { 1, 0, 0, 0,1,0,1,0,0,1},
            //                { 1, 1, 0, 0,1,0,1,0,0,1},
            //                { 0, 1, 0, 0,1,0,1,0,0,1}};

            GameOfLifeRules life = new GameOfLifeRules();
            Console.Write("Please enter an integer for a board seed");
            int[,] board = life.CreateRandomSeed();

            Console.WriteLine("Here is the starting board. Press enter to run a Life round.\n"+life.PrintGameBoard(board));
            Console.ReadLine();
            do
            {              
                int[,] newboard = life.RunLifeCycle(board);
                board = newboard;
                Console.WriteLine("Press enter to run a Life round.\n"+life.PrintGameBoard(newboard));
                //Console.ReadLine(); 
                int milliseconds = 1000;
                Thread.Sleep(milliseconds);
            } while (true);
        }
    }
}
