using NUnit.Framework;
using PaymentPlanner.Api.Services;

namespace PaymentPlanner.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Biden")]
        [TestCase("Tramp")]
        [TestCase("Obama")]
        public void Login_ShouldReturnTrue(string lastName)
        {
            // arrange

            //var lastName = "Biden";

            var service = new AuthService(); 

            //act

            var result = service.Login(lastName);


            //assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);

        }

        [Test]
        public void Login_InvokeLoginTwiceForOneLastName_ShouldReturnTrue()
        {
            // arrange

            var lastName = "Biden";

            var service = new AuthService();

            //act

            var result = service.Login(lastName);
            result = service.Login(lastName);

            //assert
            Assert.IsNotNull(UserSession.Sessions);
            Assert.IsNotEmpty(UserSession.Sessions);
            Assert.IsTrue(UserSession.Sessions.Contains(lastName));
            Assert.IsTrue(result);

        }


        [TestCase("")]
        [TestCase("TestUser")]
        [TestCase(null)]
        public void Login_ShouldReturnFalse(string lastName)
        {
            // arrange
            //var lastName = "";

            var service = new AuthService();

            //act

            var result = service.Login(lastName);

            //assert
            Assert.IsFalse(result);
        }
    }
}