using NUnit.Framework;

namespace NET1.S._2019.Tsyvis._04.Tests
{
    [TestFixture]
    public class TransformerTests
    {
        [TestCase(0, ExpectedResult = "zero")]
        [TestCase(0.01, ExpectedResult = "zero point zero one")]
        [TestCase(34, ExpectedResult = "three four")]
        [TestCase(-23.809, ExpectedResult = "minus two three point eight zero nine")]
        public string TransformToWordsTest(double number)
        {
            Transformer doubleTransformer = new Transformer();
            return doubleTransformer.TransformToWords(number);
        }
    }
}
