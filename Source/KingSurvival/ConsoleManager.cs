using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public static class ConsoleManager
    {
        public static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            StringBuilder colNumbersBuilder = new StringBuilder();
            StringBuilder dashedLineBuilder = new StringBuilder();

            for (int col = 0; col < cols; col++)
            {
                colNumbersBuilder.Append(" " + col);
                dashedLineBuilder.Append("--");
            }

            dashedLineBuilder.Append("-");

            Console.WriteLine("   " + colNumbersBuilder);
            Console.WriteLine("   " + dashedLineBuilder);

            for (int row = 0; row < rows; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   {0}\n", dashedLineBuilder);
        }
    }
}
