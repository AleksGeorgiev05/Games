using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe1
{
    public class Board
    {
        public List<string> board { get; set; }
        public Board()
        {
            board = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                board.Add(" * ");
            }
        }
        public void RenderBoard()
        {
            //Clears the previous table 
            Console.Clear();
            //The Counter variable helps us keep track of every 3rd element in the array
            int counter = 0;
            foreach (var item in board)
            {
                //On every 3rd element we will transfer to a new row
                if (counter == 3)
                {
                    counter = 0;
                    Console.WriteLine();
                }
                //Split the row
                Console.Write(item);
                counter++;
            }
            Console.WriteLine();
        }
    }
}