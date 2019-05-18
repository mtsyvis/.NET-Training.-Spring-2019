using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    using System.Collections.Generic;
    using System.Configuration;

    using BLL.Interface.Interfaces;

    using Moq;

    using NET1.S._2019.Tsyvis._22.Interfaces;

    [TestClass]
    public class UriToXmlExportServiceTests
    {
        [TestMethod]
        public void LogMockTest()
        {
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.Log(It.IsAny<string>()));
            ILogger logger = mockLogger.Object;
            logger.Log("test");
            mockLogger.Verify(l=>l.Log("test"));
        }
    }
}
