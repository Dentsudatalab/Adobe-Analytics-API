namespace Adobe.Tests.Models.Fields
{
    using Adobe.Models.Analytics;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticsDimensionFieldsTests
    {
        [Test]
        public void Field_Tags_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDimension.Fields.Tags;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("tags"));
        }

        [Test]
        public void Field_AllowedForReporting_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDimension.Fields.AllowedForReporting;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("allowedForReporting"));
        }

        [Test]
        public void Field_Categories_ShouldHaveCorrectName()
        {
            // Arrange
            var field = AnalyticsDimension.Fields.Categories;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("categories"));
        }
    }
}