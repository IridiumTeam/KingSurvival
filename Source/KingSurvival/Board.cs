namespace KingSurvival
{
    using System;
    using System.Text;

    public class Board
    {
        private readonly char[,] gameBoard;

        private readonly const byte Size = 8;

        public Board()
        {
            this.gameBoard = new char[Size, Size];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameBoard.GetLength(1); j++)
                {
                    sb.AppendFormat("{0}", this.gameBoard[i, j]);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
