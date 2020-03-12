namespace Adobe.Tests.Usage
{
    using System;
    using Adobe.Extensions;
    using Adobe.Services.Authorization;
    using Adobe.Services.Endpoints;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using NUnit.Framework;
    using Settings;

    [TestFixture]
    public class ServiceCollectionUsageTests
    {
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void SetUp()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAdobeServices();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Test]
        public void AdobeClientStore_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<IAdobeClientStore>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<AdobeClientStore>());
        }

        [Test]
        public void AdobeClientStore_MemoryCache_ShouldBeAvailable()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var settings = new AdobeSettings
            {
                ClientStore = ClientStoreType.MemoryCache
            };

            serviceCollection.AddAdobeServices(settings);
            serviceCollection.AddTransient(sp => new Mock<IMemoryCache>().Object);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var service = serviceProvider.GetService<IAdobeClientStore>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<AdobeMemoryClientStore>());
        }

        [Test]
        public void AdobeClientStore_DistributedCache_ShouldBeAvailable()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            var settings = new AdobeSettings
            {
                ClientStore = ClientStoreType.DistributedCache
            };

            serviceCollection.AddAdobeServices(settings);
            serviceCollection.AddTransient(sp => new Mock<IDistributedCache>().Object);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var service = serviceProvider.GetService<IAdobeClientStore>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<AdobeDistributedClientStore>());
        }

        [Test]
        public void AdobeAuthorizationService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<AdobeAuthorizationService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<AdobeAuthorizationService>());
        }

        [Test]
        public void DimensionService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<DimensionService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<DimensionService>());
        }

        [Test]
        public void MetricService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<MetricService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<MetricService>());
        }

        [Test]
        public void ReportService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<ReportService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<ReportService>());
        }

        [Test]
        public void SegmentService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<SegmentService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<SegmentService>());
        }

        [Test]
        public void UserService_ShouldBeAvailable()
        {
            // Act
            var service = _serviceProvider.GetService<UserService>();

            // Assert
            Assert.That(service, Is.Not.Null.And.TypeOf<UserService>());
        }
    }
}