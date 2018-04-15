using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    /// <summary>
    /// Provides methods for working with the Queue.
    /// </summary>
    /// <typeparam name="T">The data type of the Queue.</typeparam>
    public class Queue<T> : IEnumerator<T>
    {
        #region Fields

        private const int PrimaryCapacity = 5;
        private const int CapacitanceIncreaseFactor = 2;

        private T[] data;
 
        private int head;
        private int tail;

        private int size;
        private int capacity;

        private int iterator = -1;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Inintializes a new instance of the <see cref="data"/>.
        /// </summary>
        /// <param name="data">Array of elements.</param>
        public Queue(T[] data)
        {
            this.Data = data;
            this.Head = 0;
            this.Tail = data.Length - 1;
            this.Size = data.Length;
            this.Capacity = data.Length;
        }

        /// <summary>
        /// Inintializes a new instance.
        /// </summary>
        public Queue()
        {
            this.Data = new T[PrimaryCapacity];
            this.Head = -1;
            this.Tail = -1;
            this.Size = 0;
            this.Capacity = PrimaryCapacity;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the number of items in the Queue.
        /// </summary>
        public int Size
        {
            get => this.size;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Size is not be negative.", nameof(value));
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public T Current
        {
            get
            {
                if (this.iterator == -1)
                {
                    throw new InvalidOperationException("Queue is empty.");
                }

                return this.Data[this.iterator];
            }
        }

        /// <summary>
        /// Gets or sets the capacity of the Queue.
        /// </summary>
        public int Capacity
        {
            get => this.capacity;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity is not be negative.", nameof(value));
                }

                this.capacity = value;
            }
        }

        object IEnumerator.Current
        {
            get => (object)this.Current;
        }

        /// <summary>
        /// Gets or sets an array of the Queue elements.
        /// </summary>
        private T[] Data
        {
            get => this.data;

            set
            {
                if (ReferenceEquals(null, value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.data = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the first item in the Queue.
        /// </summary>
        private int Head
        {
            get => this.head;

            set
            {
                if (value < -1)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.head = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the last item in the Queue.
        /// </summary>
        private int Tail
        {
            get => this.tail;

            set
            {
                if (value < -1)
                {
                    throw new ArgumentException(nameof(value));
                }

                this.tail = value;
            }
        }

        #endregion Properties

        #region Methods for work with Queue

        /// <summary>
        /// Clears the Queue.
        /// </summary>
        public void Clear()
        {
            this.Data = new T[PrimaryCapacity];
            this.Head = -1;
            this.Tail = -1;
            this.Size = 0;
            this.Capacity = PrimaryCapacity;
        }

        /// <summary>
        /// Checks if the Queue is full.
        /// </summary>
        /// <returns>True if the Queue is full; otherwise, false.</returns>
        public bool IsFull()
        {
            return this.Capacity == this.Tail + 1;
        }

        /// <summary>
        /// Checks if the Queue is empty.
        /// </summary>
        /// <returns>True if the Queue is empty; otherwise, false</returns>
        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        /// <summary>
        /// Adds a new item to the Queue.
        /// </summary>
        /// <param name="element">The item to add.</param>
        public void Enqueue(T element)
        {
            if (this.IsFull())
            {
                this.СhangeCapacity(this.Size * CapacitanceIncreaseFactor);
            }

            if (this.IsEmpty())
            {
                this.Head = 0;
            }

            this.Data[++this.Tail] = element;
            this.Size++;
        }

        /// <summary>
        /// Removes an item from the Queue.
        /// </summary>
        /// <returns>The deleted item.</returns>
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = this.Data[this.Head];
            this.Data[this.Head] = default(T);
            this.Size--;

            if (this.IsEmpty())
            {
                this.Head = -1;
                this.Tail = -1;
            }
            else
            {
                this.Head++;
            }

            return value;
        }

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="other">The object to locate in the Queue.</param>
        /// <returns>True if item is found in the Queue; otherwise, false.</returns>
        public bool Contains(T other)
        {
            foreach (var element in this.Data)
            {
                if (element.Equals(other))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Queue.</returns>
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.Data[this.Head];
        }

        #endregion Methods for work with Queue

        #region Override methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = this.Head; i < this.Size; i++)
            {
                str.Append(this.Data[i].ToString() + "/n");
            }

            return str.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() == this.GetType())
            {
                return true;
            }

            return this.Equals((Queue<T>)obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(Queue<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Size != other.Size)
            {
                return false;
            }

            for (int i = this.Head, j = other.Head; i < this.Size; i++, j++)
            {
                if (!object.Equals(this.Data[i], other.Data[j]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Override methods

        #region IEnumerator implementation

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>True if the enumerator was successfully advanced to the next element; 
        /// false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (this.Size != 0 && this.Head != 0)
            {
                this.Resize();
                this.Reset();
            }

            if (this.iterator < this.Tail)
            {
                this.iterator++;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            this.iterator = -1;
        }

        public void Dispose()
        {
        }

        #endregion IEnumerator implementation

        #region Private methods

        private void СhangeCapacity(int capacity)
        {
            T[] tempArray = new T[capacity];

            Array.Copy(this.Data, this.Head, tempArray, 0, this.Size);
            this.Data = new T[capacity];
            Array.Copy(tempArray, this.Data, this.Size);
            this.Head = 0;
            this.Tail = this.Size - 1;
            this.Capacity = capacity;
        }

        private void Resize()
        {
            T[] temp = new T[this.Size];

            Array.Copy(this.Data, this.Head, temp, 0, this.Size);
            this.Data = temp;
            this.Head = 0;
            this.Tail = this.Size - 1;
            this.Capacity = this.Size;
        }

        #endregion Private methods
    }
}