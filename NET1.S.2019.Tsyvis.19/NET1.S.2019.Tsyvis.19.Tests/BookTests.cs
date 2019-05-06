using System;
using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._19.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book book = new Book
                                {
                                    Title = "C# in Depth",
                                    Author = "Jon Skeet",
                                    Year = 2019,
                                    PublishingHouse = "Manning",
                                    Edition = 4,
                                    Pages = 900,
                                    Price = 40
                                };

        [TestCase("ATYPH", ExpectedResult = "Jon Skeet, C# in Depth, 2019, \"Manning\"")]
        [TestCase("ATY", ExpectedResult = "Jon Skeet, C# in Depth, 2019")]
        [TestCase("AT", ExpectedResult = "Jon Skeet, C# in Depth")]
        [TestCase("TPH", ExpectedResult = "C# in Depth, \"Manning\"")]
        [TestCase("TYPH", ExpectedResult = "C# in Depth, 2019, \"Manning\"")]
        [TestCase("T", ExpectedResult = "C# in Depth")]
        public string ToStringTest_Format(string format) => this.book.ToString(format);

        [Test]
        public void ToStringTest_InvalidFormat_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.book.ToString("BLABLA"));
        }

        [Test]
        public void ToStringTest_FormatProviderTest()
        {
            Assert.AreEqual("900, 40", this.book.ToString(new BookFormatProviderTest()));
        }
    }
}
