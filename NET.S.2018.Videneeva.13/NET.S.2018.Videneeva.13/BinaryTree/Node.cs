namespace BinaryTree
{
    /// <summary>
    /// Provides methods for working with a binary search tree node.
    /// </summary>
    /// <typeparam name="T">The data type of the Node.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Inintializes a new instance of the <see cref="data"/>
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        public Node(T data)
        {
            this.Data = data;

            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// The data of the binary search tree node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Pointer to the left child node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Pointer to the pight child node.
        /// </summary>
        public Node<T> Right { get; set; }
    }
}
