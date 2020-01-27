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
            const string expectedJwt = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1Nzc4MzM4MDAsImlzcyI6Im9yZ0lkIiwic3ViIjoidGVjaElkIiwiaHR0cHM6Ly9pbXMtbmExLmFkb2JlbG9naW4uY29tL3MvZW50X2FuYWx5dGljc19idWxrX2luZ2VzdF9zZGsiOnRydWUsImF1ZCI6Imh0dHBzOi8vaW1zLW5hMS5hZG9iZWxvZ2luLmNvbS9jL2NsaWVudElkIn0.A-eBYeA6TFt9kZe4dIfCy9gfjghGCzteRoZT1vOPbCKYhiFonEZlQw4LkbyKisz0oeGnThMNimtw1E_4nUxDz-fb8gkecVn2nvkI2iUgJ4ybrSjUeHU7PMNPZ-Ag-ZUFOAuqDNCs9yFJge4l1ixP84t79_C-GpVQI03lVOrTiYKYd2Xye8YjBC5zovi9tPJNE069EUwTsKP8ZTAgDT_IxgFKZK6OAMmsM-9J8IKQ1ziXN1m5OjC2AdXIPU--rDhhpLFMisSGQh_caF3TSmFBdIPPmSinXgiYMO7ALEofxOZiDXOPASyGM3Y4sJio9kxYm59wf8q2rXf24Uamvq5F1Q";

            Assert.That(jwt, Is.EqualTo(expectedJwt));
        }
    }
}