using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12.Tests
{
    using System.Linq;

    [TestFixture]
    public class TextSeparatorTests
    {
        [TestCase(
            "Jon Skeet, jon snow, Game of thrones.Dead",
            ExpectedResult = new string[] { "Jon", "Skeet", "snow", "Game", "of", "thrones", "Dead" })]
        [TestCase("bla,bla,Bla. Bla1", ExpectedResult = new string[] { "bla", "Bla1" })]
        public IEnumerable<string> GetDistinctWordTest(string text) => TextSeparator.GetDistinctWordCaseInsensitive(text);

        [Test]
        public void GetDistinctWordsAndCountTest()
        {
            string text = "bla,bla,Bla.Bla1";

            var words = new Word[]
                            {
                                new Word { Value = "bla", Count = 2 }, new Word { Value = "Bla", Count = 1 },
                                new Word { Value = "Bla1", Count = 1 }
                            };

            CollectionAssert.AreEqual(words, TextSeparator.GetDistinctWordsAndCount(text));
        }
    }
}
