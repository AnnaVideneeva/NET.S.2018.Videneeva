namespace BinaryTree.Tests
{
    /// <summary>
    /// Provides methods for working with the point.
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Inintializes a new instance of the <see cref="x"/> and <see cref="y"/>.
        /// </summary>
        /// <param name="x">The x-axis coordinate.</param>
        /// <param name="y">The y-axis coordinate.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}