using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12
{
    /// <summary>
    /// Provide striking out in circle objects.
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public class StrikingOutInCircleProcess<T>
    {
        private LinkedList<T> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="StrikingOutInCircleProcess{T}"/> class.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <exception cref="ArgumentNullException">objects is null</exception>
        public StrikingOutInCircleProcess(IEnumerable<T> objects)
        {
            if (objects is null)
            {
                throw new ArgumentNullException($"{nameof(objects)} is null");
            }

            this.items = new LinkedList<T>(objects);
        }

        /// <summary>
        /// Starts the striking out.
        /// </summary>
        /// <returns>remaining object in circle</returns>
        public T StartStrikingOut()
        {
            var node = this.items.First;

            while (this.items.Count > 1)
            {
                var nodeNext = node.Next ?? this.items.First;
                this.items.Remove(node);
                node = nodeNext.Next ?? this.items.First;
            }

            return this.items.First.Value;
        }
    }
}
