namespace Adobe.Tests.Models.Fields
{
    using Adobe.Models.General;

    using NUnit.Framework;

    [TestFixture]
    public class SuiteCollectionItemFieldsTests
    {
        [Test]
        public void Field_Name_ShouldHaveCorrectName()
        {
            // Arrange
            var field = SuiteCollectionItem.Fields.Name;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("name"));
        }

        [Test]
        public void Field_ParentRsid_ShouldHaveCorrectName()
        {
            // Arrange
            var field = SuiteCollectionItem.Fields.ParentRsid;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("parentRsid"));
        }

        [Test]
        public void Field_Currency_ShouldHaveCorrectName()
        {
            // Arrange
            var field = SuiteCollectionItem.Fields.Currency;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("currency"));
        }

        [Test]
        public void Field_CalendarType_ShouldHaveCorrectName()
        {
            // Arrange
            var field = SuiteCollectionItem.Fields.CalendarType;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("calendarType"));
        }

        [Test]
        public void Field_TimezoneZoneinfo_ShouldHaveCorrectName()
        {
            // Arrange
            var field = SuiteCollectionItem.Fields.TimezoneZoneInfo;
            var fieldName = field.Name;

            // Assert
            Assert.That(fieldName, Is.EqualTo("timezoneZoneinfo"));
        }
    }
}
