namespace Adobe.Tests.Models.General
{
    using Adobe.Models.Analytics;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticsMetricFieldsTests
    {
        [Test]
        public void Field_Tags_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsMetric.Fields.Tags;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("tags"));
        }

        [Test]
        public void Field_AllowedForReporting_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsMetric.Fields.AllowedForReporting;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("allowedForReporting"));
        }

        [Test]
        public void Field_Categories_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsMetric.Fields.Categories;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("categories"));
        }
    }
}