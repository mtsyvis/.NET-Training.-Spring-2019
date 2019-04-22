using System;
using NUnit.Framework;
using NET1.S._2019.Tsyvis._13.Tests.Comparers;
using NET1.S._2019.Tsyvis._13.Tests.EntitiesForTest;

namespace NET1.S._2019.Tsyvis._13.Tests
{
    using System.Collections;
    using System.Linq;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Tests with integer

        [Test]
        public void GetInorderEnumerator_IntArrayUsingDefaultComparer()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 13, 15, 16, 20, 22, 25, 45 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        [Test]
        public void GetPreorderEnumerator_IntArrayUsingDefaultComparer()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 20, 15, 13, 16, 25, 22, 45 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(expectedArray, tree.GetPreorderEnumerator());
        }

        [Test]
        public void GetPostorderEnumerator_IntArrayUsingDefaultComparer()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 13, 16, 15, 22, 45, 25, 20 };
            var tree = new BinarySearchTree<int>(array);
            Assert.AreEqual(expectedArray, tree.GetPostorderEnumerator());
        }

        [Test]
        public void GetInorderEnumerator_IntArrayUsingCustomComparer()
        {
            int[] array = new[] { 20, 15, 25, 13, 16, 22, 45 };
            var expectedArray = new int[] { 45, 25, 22, 20, 16, 15, 13 };
            var tree = new BinarySearchTree<int>(array, new IntDescendingComparer());
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        #endregion

        #region Tests with string

        [Test]
        public void GetInorderEnumerator_StringArrayUsingDefaultComparer()
        {
            string[] array = new[] { "AAA", "jjj", "mng", "bbb", "kkk" };
            var expectedArray = new string[] { "AAA", "bbb", "jjj", "kkk", "mng" };
            var tree = new BinarySearchTree<string>(array);
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        [Test]
        public void GetInorderEnumerator_StringArrayUsingStringLengthAscendingComparer()
        {
            string[] array = new[] { "123456", "123", "1234", "1234567", "12", "1", string.Empty, "12345" };
            var expectedArray = new string[] { string.Empty, "1", "12", "123", "1234", "12345", "123456", "1234567" };
            var tree = new BinarySearchTree<string>(array, new StringLengthAscendingComparer());
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        #endregion

        #region Tests with Book class

        [Test]
        public void GetInorderEnumerator_BookArrayUsingDefaultComparer()
        {
            var books = new Book[]
                            {
                                new Book { Author = "Jon Skit", Title = "C# in depth", ISBN = "1", Price = 200 },
                                new Book { ISBN = "2", Author = "Bart de Smet", Title = "C# 5.0", Price = 100 },
                                new Book
                                    {
                                        ISBN = "3",
                                        Title = "Where the Crawdads Sing",
                                        Author = "Delia Owens",
                                        Price = 300
                                    }
                            };

            var expectedBooks = new Book[]
                                    {
                                        new Book { ISBN = "2", Author = "Bart de Smet", Title = "C# 5.0", Price = 100 },
                                        new Book
                                            {
                                                Author = "Jon Skit", Title = "C# in depth", ISBN = "1", Price = 200
                                            },
                                        new Book
                                            {
                                                ISBN = "3",
                                                Title = "Where the Crawdads Sing",
                                                Author = "Delia Owens",
                                                Price = 300
                                            }
                                    };
            var tree = new BinarySearchTree<Book>(books);
            CollectionAssert.AreEqual(expectedBooks, tree.GetInorderEnumerator());
        }

        [Test]
        public void GetInorderEnumerator_BookArrayUsingBookPriceAscendingComparerComparer()
        {
            var books = new Book[]
                            {
                                new Book { Author = "Jon Skit", Title = "C# in depth", ISBN = "1", Price = 3000 },
                                new Book { ISBN = "2", Author = "Bart de Smet", Title = "C# 5.0", Price = 2000 },
                                new Book
                                    {
                                        ISBN = "3",
                                        Title = "Where the Crawdads Sing",
                                        Author = "Delia Owens",
                                        Price = 305
                                    }
                            };

            var expectedBooks = new Book[]
                                    {
                                        new Book
                                            {
                                                ISBN = "3",
                                                Title = "Where the Crawdads Sing",
                                                Author = "Delia Owens",
                                                Price = 305
                                            },
                                        new Book { ISBN = "2", Author = "Bart de Smet", Title = "C# 5.0", Price = 2000 },
                                        new Book { Author = "Jon Skit", Title = "C# in depth", ISBN = "1", Price = 3000 }
                                    };
            var tree = new BinarySearchTree<Book>(books, new BookPriceAscendingComparer());
            CollectionAssert.AreEqual(expectedBooks, tree.GetInorderEnumerator());
        }

        #endregion

        #region Tests with Point struct

        [Test]
        public void GetInorderEnumerator_PointArrayPointDescendingComparer()
        {
            var array = new Point[]
                            {
                                new Point(12, 8), new Point(10, 10), new Point(8, 3), new Point(2, 17), new Point(2, 12)
                            };

            var expectedArray = new Point[]
                                    {
                                        new Point(12, 8), new Point(10, 10), new Point(8, 3), new Point(2, 17),
                                        new Point(2, 12),
                                    };
            var tree = new BinarySearchTree<Point>(array, new PointDescendingComparer());
            Assert.AreEqual(expectedArray, tree.GetInorderEnumerator());
        }

        #endregion

        public struct Point : IEquatable<Point>
        {
            public int x;

            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public bool Equals(Point other)
            {
                return this.x == other.x && this.y == other.y;
            }

            public override bool Equals(object obj)
            {
                return obj is Point other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (this.x * 397) ^ this.y;
                }
            }
        }
    }
}