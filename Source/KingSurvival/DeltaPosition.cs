namespace KingSurvival
{
    class DeltaPosition
    {
        private const int PossibleDirectionsCount = 3;

        private Direction direction;

        public int Row { get; set; }

        public int Col { get; set; }

        public DeltaPosition(Direction direction)
        {
            this.Direction = direction;
        }

        public Direction Direction
        {
            get
            {
                return this.direction;
            }
            set
            { 
                this.direction = value;

                switch (value)
                {
                    case Direction.UpRight:
                        {
                            this.Row = -1;
                            this.Col = 1;
                            break;
                        }
                    case Direction.DownRight:
                        {
                            this.Row = 1;
                            this.Col = 1;
                            break;
                        }
                    case Direction.DownLeft:
                        {
                            this.Row = 1;
                            this.Col = -1;
                            break;
                        }
                    case Direction.UpLeft:
                        {
                            this.Row = -1;
                            this.Col = 1;
                            break;
                        }
                }
            }
        }
    }
}
