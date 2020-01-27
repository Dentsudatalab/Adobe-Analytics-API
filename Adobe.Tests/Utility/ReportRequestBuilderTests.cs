namespace Adobe.Tests.Utility
{
    using System;
    using System.Linq;
    using Adobe.Models.Analytics;
    using Adobe.Models.General;
    using Adobe.Models.Ranked;
    using Adobe.Models.Report;
    using Adobe.Utility;
    using NUnit.Framework;

    [TestFixture]
    public class ReportRequestBuilderTests
    {
        [Test]
        public void WithReportSuiteId_ValidId_ShouldSetRsid()
        {
            // Arrange
            const string rsid = "rsid";
            var reportRequestBuilder = new ReportRequestBuilder();

            // Act
            var result = reportRequestBuilder
                .WithReportSuiteId(rsid)
                .Build();

            // Assert
            Assert.That(result.Rsid, Is.EqualTo(rsid));
        }

        [Test]
        public void WithFilter_SingleFilter_ShouldAddFilter()
        {
            // Arrange
            var filter = new ReportFilter
            {
                Id = "reportFilterId"
            };
            var reportRequestBuilder = new ReportRequestBuilder();

            // Act
            var result = reportRequestBuilder
                .WithFilter(filter)
                .Build();

            // Assert
            var filters = result
                .GlobalFilters
                .Where(e => e != null) // Remove date range filter
                .ToList();
            Assert.That(filters.Count, Is.EqualTo(1));
            Assert.That(filters, Is.All.EqualTo(filter));
        }

        [Test]
        public void WithDateRange_ShouldAddFilter()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();
            var from = DateTime.Today.AddDays(-1);
            var to = DateTime.Today;

            // Act
            var result = reportRequestBuilder
                .WithDateRange(from, to)
                .Build();

            // Assert
            Assert.That(result.GlobalFilters.Count, Is.EqualTo(1));
        }

        [Test]
        public void WithDimension_ShouldSetDimension()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();
            var dimension = new AnalyticsDimension
            {
                Id = "dimension"
            };

            // Act
            var result = reportRequestBuilder
                .WithDimension(dimension)
                .Build();

            // Assert
            Assert.That(result.Dimension, Is.EqualTo(dimension.Id));
        }

        [Test]
        public void WithMetric_ShouldAddMetric()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();
            var metric = new AnalyticsMetric
            {
                Id = "metric"
            };

            // Act
            var result = reportRequestBuilder
                .WithMetric(metric)
                .Build();

            // Assert
            Assert.That(result.MetricContainer.Metrics.Count, Is.EqualTo(1));
            Assert.That(result.MetricContainer.Metrics, Is.All.Property("Id").EqualTo(metric.Id));
            Assert.That(result.MetricContainer.Metrics, Is.All.Property("ColumnId").EqualTo(metric.Id));
        }

        [Test]
        public void WithLocale_ShouldSetLocale()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();
            var locale = new Locale
            {
                Country = "country"
            };

            // Act
            var result = reportRequestBuilder
                .WithLocale(locale)
                .Build();

            // Assert
            Assert.That(result.Locale, Is.EqualTo(locale));
        }

        [Test]
        public void WithSettings_ShouldSetSettings()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();
            var settings = new RankedSettings();

            // Act
            var result = reportRequestBuilder
                .WithSettings(settings)
                .Build();

            // Assert
            Assert.That(result.Settings, Is.EqualTo(settings));
        }

        [Test]
        public void Build_NoActions_ShouldBeEmpty()
        {
            // Arrange
            var reportRequestBuilder = new ReportRequestBuilder();

            // Act
            var result = reportRequestBuilder.Build();

            // Assert
            Assert.That(result.Rsid, Is.Null.Or.Empty);
            Assert.That(result.Dimension, Is.Null.Or.Empty);
            Assert.That(result.Locale, Is.Null);
            Assert.That(result.Settings, Is.Null);
            Assert.That(result.MetricContainer.Metrics, Is.Empty);
            Assert.That(result.MetricContainer.MetricFilters, Is.Empty);
            Assert.That(result.GlobalFilters, Is.All.Null);
        }
    }
}