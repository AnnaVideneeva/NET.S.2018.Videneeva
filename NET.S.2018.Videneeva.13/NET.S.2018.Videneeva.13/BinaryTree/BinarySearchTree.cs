using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinarySearchTree<T>
    {
        #region Fields

        private Node<T> root;
        private IComparer<T> comparer;
        private int count;

        #endregion Fields 

        #region Constructors

        public BinarySearchTree(IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.Root = null;
            this.Count = 0;
        }

        public BinarySearchTree(T data, IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.Root = new Node<T>(data);
            this.Count = 1;
        }

        public BinarySearchTree(T data) : this(data, Comparer<T>.Default)
        {
        }

        public BinarySearchTree() : this(Comparer<T>.Default)
        {
        }

        #endregion Constructors

        #region Properties

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

        private Node<T> Root
        {
            get => this.root;

            set
            {
                this.root = value;
            }
        }

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

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        public IEnumerable<T> PreOrder() => PreOrder(this.Root);

        public IEnumerable<T> InOrder() => InOrder(this.Root);

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