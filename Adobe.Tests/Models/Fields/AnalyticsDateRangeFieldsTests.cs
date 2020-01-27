namespace Adobe.Tests.Models.Fields
{
    using Adobe.Models.Analytics;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticsDateRangeFieldsTests
    {
        [Test]
        public void Field_Definition_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDateRange.Fields.Definition;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("definition"));
        }

        [Test]
        public void Field_OwnerFullName_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDateRange.Fields.OwnerFullName;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("ownerFullName"));
        }

        [Test]
        public void Field_Modified_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDateRange.Fields.Modified;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("modified"));
        }

        [Test]
        public void Field_Tags_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDateRange.Fields.Tags;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("tags"));
        }
    }
}