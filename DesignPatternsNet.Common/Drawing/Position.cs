namespace DesignPatternsNet.Common.Drawing
{
    /// <summary>
    /// Represents a position in 2D space
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Clone()
        {
            return new Position(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
