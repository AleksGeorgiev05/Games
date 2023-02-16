using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TicTacToe1;

namespace TicTacToe1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            //Logic of the game
            Player player1 = new Player(" x ");
            Player player2 = new Player(" o ");

            board.RenderBoard();

            while (true)
            {
                player1.Turn(board, player2);

                if (player1.CheckForWin())
                {
                    Console.WriteLine("X player wins!");
                    break;
                }

                if (player1.Choices.Count == 5)
                {
                    Console.WriteLine("No winner!");
                    break;
                }

                player2.Turn(board, player1);
                if (player2.CheckForWin())
                {
                    Console.WriteLine("O player wins!");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}