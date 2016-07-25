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
            int[,] board = { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 1, 0 } };
            GameOfLifeRules life = new GameOfLifeRules();
            Console.WriteLine("Here is the starting board. Press enter to run a Life round.\n"+life.PrintGameBoard(board));
            Console.ReadLine();
            do
            {              
                int[,] newboard = life.RunLifeCycle(board);
                board = newboard;
                Console.WriteLine("Here is the starting board. Press enter to run a Life round.\n"+life.PrintGameBoard(newboard));
                Console.ReadLine(); 
            } while (true);
        }
    }
}
