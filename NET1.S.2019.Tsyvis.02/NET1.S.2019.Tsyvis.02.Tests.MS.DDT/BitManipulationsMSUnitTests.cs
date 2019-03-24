using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NET1.S._2019.Tsyvis._02.MSUnit.Tests
{
    [TestClass]
    public class BitManipulationsMSUnitTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DDT.Test.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("NET1.S.2019.Tsyvis.02.Tests.MS.DDT\\DDT.Test.xml")]
        [TestMethod]
        public void SayHello_HelloConcatWithConcreteUserName()
        {
            int numberSource = Convert.ToInt32(TestContext.DataRow["numberSource"]);

            int numberIn = Convert.ToInt32(TestContext.DataRow["numberIn"]);

            int i = Convert.ToInt32(TestContext.DataRow["I"]);

            int j = Convert.ToInt32(TestContext.DataRow["J"]);

            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int actual = BitManipulations.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }
    }
}
