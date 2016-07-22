using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 0 } };
            GameOfLifeRules life = new GameOfLifeRules();
            Console.WriteLine(life.PrintGameBoard(board));        
            Console.ReadLine();
            int[,] newboard = life.RunLifeCycle(board);
            Console.WriteLine( life.PrintGameBoard(newboard));
            Console.ReadLine();
        }
    }
}
