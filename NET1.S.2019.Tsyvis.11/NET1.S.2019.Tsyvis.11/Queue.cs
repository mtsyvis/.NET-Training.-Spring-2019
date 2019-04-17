using System;
using System.Collections.Generic;
using System.Collections;

namespace NET1.S._2019.Tsyvis._11
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private T[] array;

        private int head;

        private int tail;

        private int size;

        private int version;

        private const int DefaultCapacity = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.array = new T[DefaultCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException">capacity can't be less then 0</exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"capacity can't be less then 0 {nameof(capacity)}");
            }

            this.array = new T[capacity];
            this.size = 0;
            this.head = 0;
            this.tail = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="ArgumentNullException">collection is null</exception>
        public Queue(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException($"collection is null {nameof(collection)}");
            }

            if (collection is ICollection<T> col)
            {
                this.array = new T[col.Count];
            }
            else
            {
                this.array = new T[DefaultCapacity];
            }

            this.size = 0;
            this.head = 0;
            this.tail = 0;

            foreach (T obj in collection)
            {
                this.Enqueue(obj);
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => this.size;

        /// <summary>
        /// Adds an object to the end
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if (this.size == this.array.Length)
            {
                int capacity = (int)((long)this.array.Length * 200L / 100L);
                if (capacity < this.array.Length + 4)
                {
                    capacity = this.array.Length + 4;
                }

                this.SetCapacity(capacity);
            }

            this.array[this.tail] = item;
            this.tail = (this.tail + 1) % this.array.Length;
            this.size++;
            this.version++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning.
        /// </summary>
        /// <returns>The object that is removed from the beginning</returns>
        /// <exception cref="InvalidOperationException">Queue is empty</exception>
        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException($"Queue is empty {nameof(this.size)}");
            }

            T obj = this.array[this.head];
            this.array[this.head] = default(T);
            this.head = (this.head + 1) % this.array.Length;
            this.size--;
            this.version++;
            return obj;
        }

        /// <summary>
        /// Returns the object at the beginning
        /// </summary>
        /// <returns>The object at the beginning</returns>
        /// <exception cref="InvalidOperationException">Queue is empty</exception>
        public T Peek()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException($"Queue is empty {nameof(this.size)}");
            }

            return this.array[this.head];
        }

        /// <summary>
        /// Removes all objects
        /// </summary>
        public void Clear()
        {
            if (this.head < this.tail)
            {
                Array.Clear((Array)this.array, this.head, this.size);
            }
            else
            {
                Array.Clear((Array)this.array, this.head, this.array.Length - this.head);
                Array.Clear((Array)this.array, 0, this.tail);
            }

            this.head = 0;
            this.tail = 0;
            this.size = 0;
            this.version++;
        }

        /// <summary>
        /// Determines whether an element is in the instance.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The object to locate in the instance. The value can be null for reference types.</returns>
        public bool Contain(T item)
        {
            int index = this.head;
            int size = this.size;

            while (size-- > 0)
            {
                if ((object)item is null)
                {
                    if ((object)this.array[index] is null)
                    {
                        return true;
                    }
                }
                else
                {
                    if ((object)this.array[index] != null && this.array[index].Equals(item))
                    {
                        return true;
                    }
                }

                index++;
            }

            return false;
        }

        /// <summary>
        /// Copies the instance elements to an existing one-dimensional System.Array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        /// <exception cref="ArgumentNullException">array is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">arrayIndex is less than zero.</exception>
        /// <exception cref="ArgumentException">The number of elements in the source instance is greater than the available space from arrayIndex to the end of the destination array.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"array is null {nameof(array)}");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException($"arrayIndex is less than zero. {nameof(arrayIndex)}");
            }

            if (array.Length - arrayIndex < this.size)
            {
                throw new ArgumentException($"The number of elements in the source instance is greater than the available space from arrayIndex to the end of the destination array.");
            }

            Array.Copy(this.array, this.head, array, arrayIndex, this.size);
        }

        /// <summary>
        /// Converts to array.
        /// </summary>
        /// <returns>A new array containing elements copied from the instance</returns>
        public T[] ToArray()
        {
            T[] objArray = new T[this.size];
            if (this.size == 0)
            {
                return objArray;
            }

            if (this.head < this.tail)
            {
                Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.size);
            }
            else
            {
                Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.array.Length - this.head);
                Array.Copy((Array)this.array, 0, (Array)objArray, this.array.Length - this.head, this.tail);
            }

            return objArray;
        }

        /// <summary>
        /// Trims the excess.
        /// </summary>
        public void TrimExcess()
        {
            if (this.size < (int)((double)this.array.Length * 0.9))
            {
                this.SetCapacity(this.size);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        private T GetElement(int i)
        {
            return this.array[(this.head + i) % this.array.Length];
        }

        private void SetCapacity(int capacity)
        {
            T[] objArray = new T[capacity];

            if (this.size > 0)
            {
                if (this.head < this.tail)
                {
                    Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.size);
                }
                else
                {
                    Array.Copy((Array)this.array, this.head, (Array)objArray, 0, this.array.Length - this.head);
                    Array.Copy((Array)this.array, 0, (Array)objArray, this.array.Length - this.head, this.tail);
                }
            }

            this.array = objArray;
            this.head = 0;
            this.tail = this.size;
            this.version++;
        }

        private struct Enumerator : IEnumerator<T>
        {
            private Queue<T> queue;

            private int index;

            private T currentElement;

            private int version;

            internal Enumerator(Queue<T> queue)
            {
                this.queue = queue;
                this.index = -1;
                this.currentElement = default(T);
                this.version = queue.version;
            }

            public T Current
            {
                get
                {
                    if (this.index < 0)
                    {
                        if (this.index == -1)
                        {
                            throw new InvalidOperationException($"Enum not started");
                        }
                        else
                        {
                            throw new InvalidOperationException($"Enum ended");
                        }
                    }

                    return this.currentElement;
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                this.index = -2;
                this.currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (this.version != this.queue.version)
                {
                    throw new InvalidOperationException($"Enum failed version");
                }

                if (this.index == -2)
                {
                    return false;
                }

                ++this.index;
                if (this.index == this.queue.size)
                {
                    this.Dispose();
                    return false;
                }

                this.currentElement = this.queue.GetElement(this.index);
                return true;
            }

            public void Reset()
            {
                this.index = -1;
                this.currentElement = default(T);
            }
        }
    }
}
