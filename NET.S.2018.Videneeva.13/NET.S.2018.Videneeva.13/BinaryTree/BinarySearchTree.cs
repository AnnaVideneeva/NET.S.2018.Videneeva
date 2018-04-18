using System;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// Provides a set of methods for working with the binary search tree.
    /// </summary>
    /// <typeparam name="T">The data type of the BinarySearchTree.</typeparam>
    public class BinarySearchTree<T>
    {
        #region Fields

        private Node<T> root;
        private IComparer<T> comparer;
        private int count;

        #endregion Fields 

        #region Constructors     

        /// <summary>
        /// Inintializes a new instance of the <see cref="collection"/> and <see cref="comparer"/>.
        /// </summary>
        /// <param name="collection">List of elements for compiling a binary search tree.</param>
        /// <param name="comparer">Comparator for the binary search tree data type.</param>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            this.AddCollection(collection);
        }

        /// <summary>
        /// Inintializes a new instance of the <see cref="comparer"/>.
        /// </summary>
        /// <param name="comparer">Comparator for the binary search tree data type.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// Inintializes a new instance of the <see cref="data"/> and <see cref="comparer"/>.
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        /// <param name="comparer">Comparator for the binary search tree data type.</param>
        public BinarySearchTree(T data, IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.Root = new Node<T>(data);
            this.Count = 1;
        }

        /// <summary>
        /// Inintializes a new instance of the <see cref="collection"/>.
        /// </summary>
        /// <param name="collection">List of elements for compiling a binary search tree.</param>
        public BinarySearchTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Inintializes a new instance of the <see cref="data"/>.
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        public BinarySearchTree(T data) : this(data, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public BinarySearchTree() : this(Comparer<T>.Default)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number of nodes in the binary search tree.
        /// </summary>
        public int Count
        {
            get => this.count;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The count of nodes of the binary tree is not be negative.", nameof(value));
                }
                    
                this.count = value;
            }
        }

        /// <summary>
        /// The root of the binary search tree.
        /// </summary>
        private Node<T> Root
        {
            get => this.root;

            set
            {
                this.root = value;
            }
        }

        /// <summary>
        /// Comparator for the binary search tree data type.
        /// </summary>
        private IComparer<T> Comparer
        {
            get => this.comparer;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    this.comparer = Comparer<T>.Default;
                }
                else
                {
                    this.comparer = value;
                }
            }
        }

        #endregion Properties

        #region Methods for working with the binary tree

        /// <summary>
        /// Adds a new node with data to the binary search tree.
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="data"/> is null.</exception>
        public void AddNode(T data)
        {
            if (ReferenceEquals(data, null))
            {
                throw new ArgumentNullException(nameof(data));
            }
                       
            if (ReferenceEquals(this.Root, null))
            {
                this.Root = new Node<T>(data);
                return;
            }

            Node<T> current = this.Root;
            Node<T> parent = null;

            while (!ReferenceEquals(current, null))
            {
                parent = current;
                if (comparer.Compare(current.Data, data) > 0)
                {
                    current = current.Left;
                }                   
                else
                {
                    current = current.Right;
                }                   
            }

            if (comparer.Compare(parent.Data, data) > 0)
            {
                parent.Left = new Node<T>(data);
            }              
            else
            {
                parent.Right = new Node<T>(data);
            }
               
            Count++;
        }

        /// <summary>
        /// Removes a node with data from the binary search tree.
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="data"/> is null.</exception>
        /// <returns>True if the deletion is successful; otherwise, false.</returns>
        public bool RemoveNode(T data)
        {
            if (ReferenceEquals(data, null))
            {
                throw new ArgumentNullException(nameof(data));
            }
                
            if (Contains(data))
            {
                if (comparer.Compare(this.Root.Data, data) == 0)
                {
                    RemoveRootNode();
                }
                else
                { 
                    this.Find(data, out Node<T> parent, out Node<T> current);
                    RemoveNode(parent, current);
                }

                Count--;
                return true;
            }

            return false;           
        }

        /// <summary>
        /// Determines whether an element is in the binary search tree.
        /// </summary>
        /// <param name="data">The data of the binary search tree node.</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="data"/> or 
        /// <see cref="root"/> is null.</exception>
        /// <returns>True if item is found in the binary search tree; otherwise, false.</returns>
        public bool Contains(T data)
        {
            if (ReferenceEquals(data, null))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (ReferenceEquals(this.Root, null))
            {
                throw new ArgumentNullException(nameof(this.Root));
            }

            Node<T> current = this.Root;

            while (!ReferenceEquals(current, null))
            {
                if (comparer.Compare(current.Data, data) == 0)
                {
                    return true;
                }                   
                else
                {
                    if (comparer.Compare(current.Data, data) > 0)
                    {
                        current = current.Left;
                    }                        
                    else
                    {
                        current = current.Right;
                    }                      
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all nodes of the binary search tree.
        /// </summary>
        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// Produces a preorder of the binary search tree.
        /// </summary>
        /// <returns>A collection of binary search tree elements.</returns>
        public IEnumerable<T> PreOrder() => PreOrder(this.Root);

        /// <summary>
        /// Produces a inorder of the binary search tree.
        /// </summary>
        /// <returns>A collection of binary search tree elements.</returns>
        public IEnumerable<T> InOrder() => InOrder(this.Root);

        /// <summary>
        /// Produces a postorder of the binary search tree.
        /// </summary>
        /// <returns>A collection of binary search tree elements.</returns>
        public IEnumerable<T> PostOrder() => PostOrder(this.Root);

        #endregion Methods for working with the binary tree

        #region Private methods of ways of traversing a tree

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            if (ReferenceEquals(node, null))
            {
                yield break;
            }               

            yield return node.Data;

            foreach (var item in PreOrder(node.Left))
            {
                yield return item;
            }              

            foreach (var item in PreOrder(node.Right))
            {
                yield return item;
            }                
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (ReferenceEquals(node, null))
            {
                yield break;
            }              

            foreach (var item in InOrder(node.Left))
            {
                yield return item;
            }
                
            yield return node.Data;

            foreach (var item in InOrder(node.Right))
            {
                yield return item;
            }              
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (ReferenceEquals(node, null))
            {
                yield break;
            }
               
            foreach (var item in PostOrder(node.Left))
            {
                yield return item;
            }             

            foreach (var item in PostOrder(node.Right))
            {
                yield return item;
            }
                
            yield return node.Data;
        }

        #endregion Private methods of ways of traversing a tree

        #region Private methods

        private void AddCollection(IEnumerable<T> collection)
        {
            if (ReferenceEquals(null, collection))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var value in collection)
            {
                this.AddNode(value);
            }
        }

        private void RemoveRootNode()
        {
            if (object.ReferenceEquals(null, this.Root.Right) && object.ReferenceEquals(null, this.Root.Left))
            {
                this.Root = null;
                return;
            }
  
            if (object.ReferenceEquals(null, this.Root.Left))
            {
                this.Root = this.Root.Right;
                return;
            }

            if (object.ReferenceEquals(null, this.Root.Right))
            {
                this.Root = this.Root.Left;
                return;
            }

            Node<T> current = this.Root.Right;

            if (object.ReferenceEquals(null, current.Left))
            {
                this.Root = current;
                return;
            }

            Node<T> prevCurrent = this.Root;

            while (!object.ReferenceEquals(current.Left, null))
            {
                prevCurrent = current;
                current = current.Left;
            }

            prevCurrent.Left = current.Right;
            current.Right = root.Right;
            current.Left = root.Left;
            this.Root = current;
        }

        private void RemoveNode(Node<T> parent, Node<T> current)
        {
            if (ReferenceEquals(null, current.Right) && ReferenceEquals(null, current.Left))
            {
                if (comparer.Compare(parent.Data, current.Data) > 0)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }

                return;   
            }
            
            if (ReferenceEquals(null, current.Left))
            {
                if (comparer.Compare(parent.Data, current.Data) > 0)
                {
                    parent.Left = current.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }

                return;
            }
            
            if (ReferenceEquals(null, current.Right))
            {
                if (comparer.Compare(parent.Data, current.Data) > 0)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Left;
                }

                return;
            }

            Node<T> prevCurrent = current;
            Node<T> temp = current;
            current = current.Right;
            
            while (!ReferenceEquals(current.Left, null))
            {
                prevCurrent = current;
                current = current.Left;
            }
            
            if (comparer.Compare(parent.Data, current.Data) > 0)
            {
                parent.Left = current;
            }
            else
            {
                parent.Right = current;
            }
                
            current.Left = temp.Left;
            prevCurrent.Left = prevCurrent.Left.Right;
            current.Right = temp.Right;
        }

        private void Find(T data, out Node<T> parent, out Node<T> current)
        {
            current = this.Root;
            parent = null;

            while (comparer.Compare(current.Data, data) != 0)
            {
                parent = current;

                if (comparer.Compare(current.Data, data) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
        }

        #endregion Private methods
    }
}