using System;
using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._11.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Contain_EnqueueAndDequeueItemCheckItemForContained()
        {
            var array = new int[] { 6, 3, 8, 2, 9 };
            var queue = new Queue<int>(array);

            queue.Dequeue();
            queue.Dequeue();

            Assert.IsTrue(queue.Contain(9));
            Assert.IsFalse(queue.Contain(3));
        }

        [Test]
        public void GetEnumerator_CompareItem_WellCompared()
        {
            var array = new int[] { 6, 3, 8, 2, 9 };
            var queue = new Queue<int>(array);

            IEnumerator<int> enumerator = queue.GetEnumerator();
            enumerator.MoveNext();

            Assert.AreEqual(array[0], enumerator.Current);
        }

        [Test]
        public void ToArrayTest()
        {
            var expectedArray = new string[] { "bla1", "bla2", "bla3" };
            var queue = new Queue<string>();

            queue.Enqueue("bla1");
            queue.Enqueue("bla2");
            queue.Enqueue("bla3");

            Assert.AreEqual(expectedArray, queue.ToArray());
        }

        [Test]
        public void CopyToTest()
        {
            var expectedArray = new int[] { 6, 3, 8, 2, 9 };
            var queue = new Queue<int>(expectedArray);

            var actualArray = new int[expectedArray.Length];
            queue.CopyTo(actualArray, 0);

            Assert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void Peek_GetItemWhenQueueIsEmpty_ThrowInvalidOperationException()
        {
            var queue = new Queue<bool>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void GetEnumerator_ChangeQueueInForeach_ThrowInvalidOperationException()
        {
            var queue = new Queue<int>(new int[] { 1, 2, 4, 5, 6 });

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var item in queue)
                {
                    queue.Enqueue(4);
                }
            });
        }
    }
}
