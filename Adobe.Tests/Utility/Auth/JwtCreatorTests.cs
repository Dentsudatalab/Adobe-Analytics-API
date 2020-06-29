namespace Adobe.Tests.Utility.Auth
{
    using System;
    using System.IO;

    using Adobe.Utility.Auth;

    using NUnit.Framework;

    [TestFixture]
    public class JwtCreatorTests
    {
        private string _privateKey;

        [SetUp]
        public void SetUp()
        {
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir, "Utility/Auth/test_private_key.txt");
            _privateKey = File.ReadAllText(path);
        }

        [Test]
        public void CreateJwt_ShouldCreateCorrectToken()
        {
            // Arrange
            var exp = new DateTime(2020, 1, 1, 0, 0, 0);
            var authValues = new AuthValues
            {
                OrganizationId = "orgId",
                TechnicalAccountId = "techId",
                ClientId = "clientId",
                PrivateKey = _privateKey
            };

            // Act
            var jwt = JwtCreator.CreateJwt(authValues, exp);

            // Assert
            const string expectedJwt =
                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1Nzc4Mzc0MDAsImlzcyI6Im9yZ0lkIiwic3ViIjoidGVjaElkIiwiaHR0cHM6Ly9pbXMtbmExLmFkb2JlbG9naW4uY29tL3MvZW50X2FuYWx5dGljc19idWxrX2luZ2VzdF9zZGsiOnRydWUsImF1ZCI6Imh0dHBzOi8vaW1zLW5hMS5hZG9iZWxvZ2luLmNvbS9jL2NsaWVudElkIn0.t-9dajjHsuxCNghRPV0h82r7JEpTX5uUfUi_UGbiqOlJlBWBeXyzxaHIqWzWOLNKaJeK6Kzmv72zc8KrPZzyqtjvd5Q98A4CwFqxyNMatS-7aCWPX46bP4PaguWHSwt-th9SkB6vBIvwR7cs0wmgJJdrDn-Rf32B0m_xh3fx4aV7w3BDJqCujbrx98VmP6LMRyVSvwikjHx9vQ4YExjDnhNazeW0_P7c97dBxXInFHg1_sF0cAjWoDKSSV-PF4HSexLnLaPAx2bMj1ZGJHAf6JXICqVqRzxXkEsoWuirHxdJY5NSlQfkw4jFXl1CPrPI9doUlZ2X7hW_f6_Afu6M8g";

            Assert.That(jwt, Is.EqualTo(expectedJwt));
        }
    }
}
