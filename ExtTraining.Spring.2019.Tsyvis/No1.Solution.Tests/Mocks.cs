using Moq;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    using No1.Solution.Interfaces;
    
    [TestFixture]
    public class Mocks
    {
        [Test]
        public void RunMockTest1()
        {

            Mock<IVerifyer> mockVerifyer = new Mock<IVerifyer>();
            mockVerifyer.Setup(p => p.VerifyPassword(It.IsAny<string>()));

            IVerifyer verifyer = mockVerifyer.Object;

            verifyer.VerifyPassword("test");
            mockVerifyer.Verify(vr => vr.VerifyPassword("test"), Times.Once);
        }
    }
}
