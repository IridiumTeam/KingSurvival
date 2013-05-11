namespace KingSurvival
{
    public class King : GamePiece
    {
        // character - K, getter - inherited
        // constructor - takes char
        // position - inherited

        private const Position KingPosition = new Position(7,3);

        public King() 
            : base('K', KingPosition)
        {

        }
    }
}
