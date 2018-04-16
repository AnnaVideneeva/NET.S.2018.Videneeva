using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
            if (!Contains(data))
            {
                return false;
            }
           
            if (comparer.Compare(this.Root.Data, data) == 0)
            {
                RemoveRoot(this.Root, data);
            }              
            else
            {
                RemoveAt(this.Root, data);
            }

            Count--;
            return true;
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

        #endregion Methods for working with the binary tree
    }
}
