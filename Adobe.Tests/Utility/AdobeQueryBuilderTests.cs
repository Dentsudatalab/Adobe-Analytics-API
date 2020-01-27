namespace Adobe.Tests.Utility
{
    using System;
    using Adobe.Models.Analytics;
    using Adobe.Utility;
    using NUnit.Framework;

    [TestFixture]
    public class AdobeQueryBuilderTests
    {
        private AdobeQueryBuilder _queryBuilder;

        [SetUp]
        public void SetUp()
        {
            const string relativePath = "test";
            const string companyId = "company";

            _queryBuilder = new AdobeQueryBuilder(relativePath)
                .WithCompanyId(companyId);
        }

        [Test]
        public void WithFields_SingleField_ShouldAddToQuery()
        {
            // Arrange
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = _queryBuilder
                .WithFields(fields)
                .Build();

            // Assert
            var query = result.Query;
            const string expectedQuery = "?expansion=categories";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithFields_MultipleFields_ShouldAddToQuery()
        {
            // Arrange
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories,
                AnalyticsDimension.Fields.Tags
            };

            // Act
            var result = _queryBuilder
                .WithFields(fields)
                .Build();

            // Assert
            var query = result.Query;
            const string expectedQuery = "?expansion=categories%2ctags";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithParam_ShouldAddToQuery()
        {
            // Arrange
            const string paramKey = "key";
            const string paramValue = "value";

            // Act
            var result = _queryBuilder
                .WithParam(paramKey, paramValue)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?{paramKey}={paramValue}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithParamIf_False_ShouldNotAddToQuery()
        {
            // Arrange
            const string paramKey = "key";
            const string paramValue = "value";

            // Act
            var result = _queryBuilder
                .WithParamIf(false, paramKey, paramValue)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = string.Empty;

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithParamIf_True_ShouldAddToQuery()
        {
            // Arrange
            const string paramKey = "key";
            const string paramValue = "value";

            // Act
            var result = _queryBuilder
                .WithParamIf(true, paramKey, paramValue)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?{paramKey}={paramValue}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithReportSuiteId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            const string id = "reportSuiteId";

            // Act
            var result = _queryBuilder
                .WithReportSuiteId(id)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?rsid={id}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void WithCompanyId_ShouldBeInQuery()
        {
            // Arrange
            const string companyId = "companyId";

            // Act
            var result = _queryBuilder
                .WithCompanyId(companyId)
                .Build();

            // Assert
            StringAssert.Contains(companyId, result.AbsolutePath);
        }

        [Test]
        public void FieldAndParam_ShouldIncludeBoth()
        {
            // Arrange
            const string paramKey = "key";
            const string paramValue = "value";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = _queryBuilder
                .WithFields(fields)
                .WithParam(paramKey, paramValue)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?expansion=categories&{paramKey}={paramValue}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void FieldAndRsid_ShouldIncludeBoth()
        {
            // Arrange
            const string rsid = "rsid";
            var fields = new[]
            {
                AnalyticsDimension.Fields.Categories
            };

            // Act
            var result = _queryBuilder
                .WithFields(fields)
                .WithReportSuiteId(rsid)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?expansion=categories&rsid={rsid}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }

        [Test]
        public void RsidAndParam_ShouldIncludeBoth()
        {
            // Arrange
            const string paramKey = "key";
            const string paramValue = "value";
            const string rsid = "rsid";

            // Act
            var result = _queryBuilder
                .WithParam(paramKey, paramValue)
                .WithReportSuiteId(rsid)
                .Build();

            // Assert
            var query = result.Query;
            var expectedQuery = $"?rsid={rsid}&{paramKey}={paramValue}";

            Assert.That(query, Is.EqualTo(expectedQuery));
        }
    }
}