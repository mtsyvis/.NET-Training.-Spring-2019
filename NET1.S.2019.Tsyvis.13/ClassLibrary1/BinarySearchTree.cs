using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._13
{
    /// <summary>
    /// Represent Binary Tree
    /// </summary>
    /// <typeparam name="T">The type of nodes</typeparam>
    public class BinarySearchTree<T>
    {
        private Node root;

        private IComparer<T> comparer;

        private int count;

        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public BinarySearchTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            if (collection is null)
            {
                throw new ArgumentNullException($"collection is null");
            }

            foreach (T item in collection)
            {
                if (!this.Contains(item))
                {
                    this.Add(item);
                }
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => this.count;

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>true if item has been added; otherwise - false</returns>
        public bool Add(T item)
        {
            return AddIfNotPresent(item, ref this.root);
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {
            return FindNode(item) != null;
        }

        /// <summary>
        /// Gets the preorder enumerator.
        /// </summary>
        /// <returns>The preorder iterator</returns>
        public IEnumerable<T> GetPreorderEnumerator()
        {
            return this.Preorder(this.root);
        }

        /// <summary>
        /// Gets the post order enumerator.
        /// </summary>
        /// <returns>The post order iterator</returns>
        public IEnumerable<T> GetPostorderEnumerator()
        {
            return this.Postorder(this.root);
        }

        /// <summary>
        /// Gets the inorder enumerator.
        /// </summary>
        /// <returns>The inorder iterator</returns>
        public IEnumerable<T> GetInorderEnumerator()
        {
            return this.Inorder(this.root);
        }

        #region Helper methods and class

        private IEnumerable<T> Inorder(Node parent)
        {
            if (parent == null)
            {
                yield break;
            }

            foreach (var item in this.Inorder(parent.left))
            {
                yield return item;
            }

            yield return parent.item;
            foreach (var item in this.Inorder(parent.right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> Preorder(Node parent)
        {
            if (parent == null)
            {
                yield break;
            }

            yield return parent.item;
            foreach (var item in this.Preorder(parent.left))
            {
                yield return item;
            }

            foreach (var item in this.Preorder(parent.right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> Postorder(Node parent)
        {
            if (parent == null)
            {
                yield break;
            }

            foreach (var item in this.Postorder(parent.left))
            {
                yield return item;
            }

            foreach (var item in this.Postorder(parent.right))
            {
                yield return item;
            }

            yield return parent.item;
        }

        private Node FindNode(T item)
        {
            Node current = this.root;
            while (current != null)
            {
                int order = this.comparer.Compare(item, current.item);
                if (order == 0)
                {
                    return current;
                }

                current = order > 0 ? current.right : current.left;
            }

            return null;
        }

        private bool AddIfNotPresent(T item, ref Node parent)
        {
            if (parent == null)
            {
                parent = new Node(item);
                this.count++;
                this.version++;
                return true;
            }

            int order = this.comparer.Compare(item, parent.item);

            if (order == 0)
            {
                return false;
            }

            if (order > 0)
            {
                return this.AddIfNotPresent(item, ref parent.right);
            }
            else
            {
                return this.AddIfNotPresent(item, ref parent.left);
            }
        }

        internal class Node
        {
            public T item;

            public Node left;

            public Node right;

            public Node(T item)
            {
                this.item = item;
            } 
        }

        #endregion
    }
}
