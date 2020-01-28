namespace Adobe.Tests.Services.Endpoints
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Adobe.Models.Analytics;
    using Adobe.Models.General;
    using Adobe.Services.Authorization;
    using Adobe.Services.Endpoints;
    using Adobe.Utility.Auth;
    using Moq;
    using NUnit.Framework;
    using RichardSzalay.MockHttp;

    [TestFixture]
    public class ReportSuiteServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<MoqMessageHandler> _mockHttpClient;
        private Mock<AdobeAuthorizationService> _mockAdobeAuthorizationService;

        private AuthValues _authValues;

        [SetUp]
        public void SetUp()
        {
            this._mockRepository = new MockRepository(MockBehavior.Loose);

            this._mockAdobeAuthorizationService = this._mockRepository.Create<AdobeAuthorizationService>(null);
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

        private ReportSuiteService CreateService()
        {
            var service = new ReportSuiteService(
                _mockHttpClient.Object.ToHttpClient(),
                this._mockAdobeAuthorizationService.Object);
            service.SetAuthValues(_authValues);

            return service;
        }

        [Test]
        public async Task GetReportSuites_Default_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{\"content\": [], \"totalElements\": 0}");

            var service = this.CreateService();
            var fields = new[] { SuiteCollectionItem.Fields.Name };

            // Act
            var result = await service.GetReportSuites(fields);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/collections/suites";
            var path = calledUri.AbsolutePath;

            var expectedQuery = "?expansion=name&limit=1000&page=0";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetReportSuites_RsIds_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{\"content\": [], \"totalElements\": 0}");

            var service = this.CreateService();
            var fields = new[] { SuiteCollectionItem.Fields.Name };
            var rsids = new[] { "123,321" };

            // Act
            var result = await service.GetReportSuites(fields, rsids);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/collections/suites";
            var path = calledUri.AbsolutePath;

            var expectedQuery = "?expansion=name&rsids=123%2c321&limit=1000&page=0";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetReportSuites_RsidsContains_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{\"content\": [], \"totalElements\": 0}");

            var service = this.CreateService();
            var fields = new[] { SuiteCollectionItem.Fields.Name };
            var rsidsContains = "123";

            // Act
            var result = await service.GetReportSuites(fields, rsidContains: rsidsContains);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/collections/suites";
            var path = calledUri.AbsolutePath;

            var expectedQuery = "?expansion=name&rsidContains=123&limit=1000&page=0";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetReportSuites_MultiPage_ShouldMatchUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .WithQueryString("page", "0")
                .Respond("application/json", "{\"content\": [], \"totalElements\": 1500}");
            _mockHttpClient.Object
                .When("*")
                .WithQueryString("page", "1")
                .Respond("application/json", "{\"content\": [], \"totalElements\": 1500, \"lastPage\": true}");

            var service = this.CreateService();
            var fields = new[] { SuiteCollectionItem.Fields.Name };

            // Act
            var result = await service.GetReportSuites(fields);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/collections/suites";
            var path = calledUri.AbsolutePath;

            var expectedQuery = "?expansion=name&limit=1000&page=1";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public async Task GetReportSuiteById_ShouldCallValidUri()
        {
            // Arrange
            Uri calledUri = null;
            _mockHttpClient
                .Setup(e => e.Intermediate(It.IsAny<HttpRequestMessage>()))
                .Callback<HttpRequestMessage>(e => calledUri = e.RequestUri);

            _mockHttpClient.Object
                .When("*")
                .Respond("application/json", "{}");

            var service = this.CreateService();
            const string rsid = "rsid";
            var fields = new[] { SuiteCollectionItem.Fields.Name };

            // Act
            var result = await service.GetReportSuiteById(rsid, fields);

            // Assert
            var expectedPath = $"/api/{_authValues.CompanyId}/collections/suites/{rsid}";
            var path = calledUri.AbsolutePath;

            var expectedQuery = "?expansion=name";
            var query = calledUri.Query;

            Assert.That(path, Is.EqualTo(expectedPath));
            Assert.That(query, Is.EqualTo(expectedQuery));
        }
    }
}