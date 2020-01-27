namespace Adobe.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void Deconstruct_SinglePair_ShouldDeconstruct()
        {
            // Arrange
            var dictionary = new Dictionary<string, string>();

            const string key = "key";
            const string value = "value";

            // Act
            dictionary.Add(key, value);

            // Assert
            var (insertedKey, insertedValue) = dictionary.First(); // Check for deconstruction

            Assert.That(insertedKey, Is.EqualTo(key));
            Assert.That(insertedValue, Is.EqualTo(value));
        }
    }
}