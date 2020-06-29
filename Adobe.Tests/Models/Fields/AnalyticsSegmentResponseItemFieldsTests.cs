namespace Adobe.Tests.Models.Fields
{
    using Adobe.Models.Analytics;

    using NUnit.Framework;

    [TestFixture]
    public class AnalyticsSegmentResponseItemFieldsTests
    {
        [Test]
        public void Field_ReportSuiteName_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.ReportSuiteName;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("reportSuiteName"));
        }

        [Test]
        public void Field_OwnerFullName_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.OwnerFullName;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("ownerFullName"));
        }

        [Test]
        public void Field_Modified_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.Modified;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("modified"));
        }

        [Test]
        public void Field_Tags_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.Tags;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("tags"));
        }

        [Test]
        public void Field_Compatibility_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.Compatibility;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("compatibility"));
        }

        [Test]
        public void Field_Definition_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.Definition;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("definition"));
        }

        [Test]
        public void Field_PublishingStatus_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.PublishingStatus;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("publishingStatus"));
        }

        [Test]
        public void Field_DefinitionLastModified_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.DefinitionLastModified;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("definitionLastModified"));
        }

        [Test]
        public void Field_Categories_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsSegmentResponseItem.Fields.Categories;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("categories"));
        }
    }
}
