using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._13.Tests
{
    using System.Linq;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void Add_IntArray()
        {
            int[] array = new int[] { 1, 10, 5, -9, 8, 18, 100, 8, 100 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(7, tree.Count);
        }

        [Test]
        public void GetInorderEnumerator()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 13, 15, 16, 20, 22, 25, 45 };
            var tree = new BinarySearchTree<int>(array);
            var actualArray = tree.GetInorderEnumerator().ToArray();
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        [Test]
        public void GetPreorderEnumerator()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 20, 15, 13, 16, 25, 22, 45 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(expectedArray, tree.GetPreorderEnumerator());
        }

        [Test]
        public void GetPostorderEnumerator()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 13, 16, 15, 22, 45, 25, 20 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(expectedArray, tree.GetPostorderEnumerator());
        }
    }
}
