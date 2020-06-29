using Adobe.Services.Authorization;

using Moq;

using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace Adobe.Tests.Services.Authorization
{
    using Adobe.Utility.Auth;

    [TestFixture]
    public class AdobeAuthorizationServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<AdobeClientStore> _mockAdobeClientStore;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockAdobeClientStore = _mockRepository.Create<AdobeClientStore>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.VerifyAll();
        }

        private AdobeAuthorizationService CreateService()
        {
            return new AdobeAuthorizationService(_mockAdobeClientStore.Object);
        }

        [Test]
        public void IsClientLoggedIn_ClientNull_ShouldReturnFalse()
        {
            // Arrange
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns((IdentityClient)null);

            var service = CreateService();

            // Act
            var result = service.IsClientLoggedIn("someToken");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsClientLoggedIn_ClientExpired_ShouldReturnFalse()
        {
            // Arrange
            var client = new IdentityClient
            {
                ExpiresAt = DateTime.Now.AddMinutes(-10)
            };
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns(client);

            var service = CreateService();

            // Act
            var result = service.IsClientLoggedIn("someToken");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsClientLoggedIn_DifferentToken_ShouldReturnFalse()
        {
            // Arrange
            const string correctToken = "someToken";
            const string invalidToken = "someOtherToken";

            var client = new IdentityClient
            {
                ExpiresAt = DateTime.Now.AddMinutes(10),
                RefreshToken = correctToken
            };
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns(client);

            var service = CreateService();

            // Act
            var result = service.IsClientLoggedIn(invalidToken);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsClientLoggedIn_CorrectToken_ShouldReturnTrue()
        {
            // Arrange
            const string correctToken = "someToken";

            var client = new IdentityClient
            {
                ExpiresAt = DateTime.Now.AddMinutes(10),
                RefreshToken = correctToken
            };
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns(client);

            var service = CreateService();

            // Act
            var result = service.IsClientLoggedIn(correctToken);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetClient_NotLoggedIn_ShouldThrow()
        {
            // Arrange
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns((IdentityClient)null);

            var service = CreateService();

            // Assert
            Assert.Throws<InvalidOperationException>(() => service.GetClient(null));
        }

        [Test]
        public void GetClient_LoggedIn_ShouldReturnClient()
        {
            // Arrange
            const string token = "someToken";

            var client = new IdentityClient
            {
                ExpiresAt = DateTime.Now.AddMinutes(10),
                RefreshToken = token
            };
            _mockAdobeClientStore
                .SetupGet(e => e.Client)
                .Returns(client);

            var service = CreateService();

            // Act
            var result = service.GetClient(token);

            // Assert
            Assert.That(result.RefreshToken, Is.EqualTo(client.RefreshToken));
        }
    }
}
