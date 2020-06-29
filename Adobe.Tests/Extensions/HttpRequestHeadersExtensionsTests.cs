using Adobe.Extensions;

using Moq;

using NUnit.Framework;

using System;

namespace Adobe.Tests.Extensions
{
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    [TestFixture]
    public class HttpRequestHeadersExtensionsTests
    {
        private HttpRequestHeaders CreateHeaders()
        {
            return new HttpClient().DefaultRequestHeaders;
        }

        [Test]
        public void Set_EmptyHeaders_ShouldAddHeader()
        {
            // Arrange
            const string headerName = "header";
            const string headerValue = "value";

            var headers = CreateHeaders();

            // Act
            headers.Set(headerName, headerValue);

            // Assert
            Assert.That(headers.TryGetValues(headerName, out var values), Is.True);
            Assert.That(values, Is.All.EqualTo(headerValue));
            Assert.That(values.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Set_SameHeader_ShouldOverwrite()
        {
            // Arrange
            const string headerName = "header";
            const string headerValue = "value";
            const string replaceHeaderValue = "newValue";

            var headers = CreateHeaders();

            // Act
            headers.Set(headerName, headerValue);
            headers.Set(headerName, replaceHeaderValue);

            // Assert
            var values = headers.GetValues(headerName);
            Assert.That(values, Is.All.EqualTo(replaceHeaderValue));
            Assert.That(values.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Set_DifferentHeader_ShouldAddBoth()
        {
            // Arrange
            const string firstHeaderName = "header1";
            const string secondHeaderName = "header2";
            const string headerValue = "value";

            var headers = CreateHeaders();

            // Act
            headers.Set(firstHeaderName, headerValue);
            headers.Set(secondHeaderName, headerValue);

            // Assert
            Assert.That(headers.Contains(firstHeaderName), Is.True);
            Assert.That(headers.Contains(secondHeaderName), Is.True);
        }
    }
}
