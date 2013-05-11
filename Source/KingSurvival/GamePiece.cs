namespace KingSurvival
{
    public abstract class GamePiece
    {
        private readonly char body;

        private readonly Position position;

        public GamePiece(char body, Position position)
        {
            this.Body = body;
            this.Position = position;
        }

        public char Body
        {
            get
            {
                return this.body;
            }
            private set;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set;
        }
    }
}
