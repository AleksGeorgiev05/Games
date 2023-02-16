using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe1
{
    public class Player
    {
        public List<int> Choices = new List<int>();
        public string playerSign { get; set; }

        public Player(string sign)
        {
            playerSign = sign;
        }

        public bool CheckForWin()
        {
            List<List<int>> winingPositions = new List<List<int>>
            { new List<int>{ 1, 2, 3 } , new List<int> { 4, 5, 6 } , new List<int> { 7, 8, 9 },
              new List<int>{ 1, 4, 7 },new List<int>{ 2, 5, 8 },new List<int>{ 3, 6, 9 },
              new List<int>{ 1, 5, 9 },new List<int>{ 3, 5, 7 }};

            foreach (var item in winingPositions)
            {
                if (Choices.Intersect(item).Count() == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public void Turn(Board board, Player enemyPlayer)
        {
            int input;
            bool wrongpos = false;

            do
            {
                board.RenderBoard();
                if (wrongpos)
                {
                    Console.WriteLine("Enter valid position");
                }
                input = int.Parse(Console.ReadLine());
                wrongpos = true;
            }

            while (enemyPlayer.Choices.Contains(input) || this.Choices.Contains(input));
            {
                Choices.Add(input);
                board.board[input - 1] = playerSign;
                board.RenderBoard();
            }
        }
    }
}