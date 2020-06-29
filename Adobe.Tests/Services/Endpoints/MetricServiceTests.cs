namespace Adobe.Tests.Services.Endpoints
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Adobe.Models.Analytics;
    using Adobe.Services.Authorization;
    using Adobe.Services.Endpoints;
    using Adobe.Utility.Auth;

    using Moq;

    using NUnit.Framework;

    using RichardSzalay.MockHttp;

    [TestFixture]
    public class MetricServiceTests
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

        private MetricService CreateService()
        {
            var service = new MetricService(
                _mockHttpClient.Object.ToHttpClient(),
                _mockAdobeAuthorizationService.Object);
            service.SetAuthValues(_authValues);

            return service;
        }

        [Test]
        public async Task GetMetrics_NoBools_ShouldMatchUri()
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
                AnalyticsMetric.Fields.Categories
            };

            // Act
            var result = await service.GetMetrics(rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/metrics";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetMetrics_Bools_ShouldMatchUri()
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
                AnalyticsMetric.Fields.Categories
            };

            // Act
            var result = await service.GetMetrics(rsid, fields, locale, true);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/metrics";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}&segmentable=true";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetMetricById_ShouldCallValidUri()
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
            const string metric = "my_metric";
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsMetric.Fields.Categories
            };

            // Act
            var result = await service.GetMetricById(metric, rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/metrics/{metric}";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetMetricById_MetricWithVariable_ShouldReplace()
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
            const string metric = "metrics/my_metric";
            const string trimmedMetric = "my_metric";
            const string rsid = "rsid";
            const string locale = "en_US";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = await service.GetMetricById(metric, rsid, fields, locale);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/metrics/{trimmedMetric}";
            var path = calledUri.AbsolutePath;

            var expectedQuery = $"?expansion=categories&rsid={rsid}&locale={locale}";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }
    }
}
