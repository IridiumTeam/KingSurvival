namespace KingSurvival
{
    using System;

    public class Position
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
