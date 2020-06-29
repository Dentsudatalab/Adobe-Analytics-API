namespace Adobe.Tests.Services.Endpoints
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Adobe.Extensions;
    using Adobe.Models.Analytics;
    using Adobe.Services.Authorization;
    using Adobe.Services.Endpoints;
    using Adobe.Utility;
    using Adobe.Utility.Auth;

    using Moq;

    using NUnit.Framework;

    using RichardSzalay.MockHttp;

    [TestFixture]
    public class DimensionServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<MoqMessageHandler> _mockHttpClient;
        private Mock<AdobeAuthorizationService> _mockAdobeAuthorizationService;

        private AuthValues _authValues;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);

            _mockAdobeAuthorizationService = _mockRepository.Create<AdobeAuthorizationService>(null);
            _mockHttpClient = _mockRepository.Create<MoqMessageHandler>();
            _mockHttpClient.CallBase = true;

            _authValues = new AuthValues()
            {
                CompanyId = "company"
            };

            _mockAdobeAuthorizationService
                .Setup(e => e.AuthorizeClient(_authValues))
                .ReturnsAsync(new IdentityClient());
        }

        private DimensionService CreateService()
        {
            var service = new DimensionService(
                _mockHttpClient.Object.ToHttpClient(),
                _mockAdobeAuthorizationService.Object);
            service.SetAuthValues(_authValues);

            return service;
        }

        [Test]
        public async Task GetDimensions_NoBools_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "[]");

            var service = CreateService();
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = await service.GetDimensions(rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/dimensions";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetDimensions_Bools_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "[]");

            var service = CreateService();
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = await service.GetDimensions(rsid, fields, locale, true, true, true);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/dimensions";
            var path = calledUri.AbsolutePath;

            var expectedQuery =
                $"?expansion=categories&rsid={rsid}&locale={locale}&segmentable=true&reportable=true&classifiable=true";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetDimensionById_ShouldCallValidUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{}");

            var service = CreateService();
            const string dimension = "my_dimension";
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = await service.GetDimensionById(dimension, rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/dimensions/{dimension}";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetDimensionById_DimensionWithVariable_ShouldReplace()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{}");

            var service = CreateService();
            const string dimension = "variables/my_dimension";
            const string trimmedDimension = "my_dimension";
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = await service.GetDimensionById(dimension, rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/dimensions/{trimmedDimension}";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }
    }
}
