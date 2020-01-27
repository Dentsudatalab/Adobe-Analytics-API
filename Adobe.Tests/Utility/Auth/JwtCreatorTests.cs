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
            const string expectedJwt = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1Nzc4MzM4MDAsImlzcyI6Im9yZ0lkIiwic3ViIjoidGVjaElkIiwiaHR0cHM6Ly9pbXMtbmExLmFkb2JlbG9naW4uY29tL3MvZW50X2FuYWx5dGljc19idWxrX2luZ2VzdF9zZGsiOnRydWUsImF1ZCI6Imh0dHBzOi8vaW1zLW5hMS5hZG9iZWxvZ2luLmNvbS9jL2NsaWVudElkIn0.bIhgEHiX1VmOItD7vDGxrO6MWH4eoUMu-YorohMCpcMTj4rlCXI82GmH-SBZ2Au-H_cPEZDw2KYO7CkyDrlzGk-tsBAOMT-fJw_mAMS6oFiOkUEIhWBjnkZPB0lrGlaOmsmtcFp6KrcUL0Ls5CYTh1XohMNbAc3ItjyljsR1eEijjiWBib6Sy3DkwzsO-YjFl4iF-E6EMM2GraVIgfFP0Bm2aLBUfXr1bjJlcPT6dZ0MXP5PGZlOuW1XOeOBmeOqaJoTOj2eiT8Tol0ojhScXUKX8OXJzHrJqkC5zHZN64Y3oNCVBbigegGsyhrRHUk-J7x3tvDILhSIiuLfDyw_GA";

            Assert.That(jwt, Is.EqualTo(expectedJwt));
        }
    }
}