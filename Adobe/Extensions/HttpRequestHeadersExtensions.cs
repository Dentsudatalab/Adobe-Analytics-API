namespace Adobe.Extensions
{
    using System.Net.Http.Headers;

    public static class HttpRequestHeadersExtensions
    {
        /// <summary>
        /// Adds/overwrites a header value.
        /// </summary>
        /// <param name="headers">The headers object to add/overwrite a header value to.</param>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public static void Set(this HttpRequestHeaders headers, string name, string value)
        {
            if (headers.Contains(name)) headers.Remove(name);
            headers.Add(name, value);
        }
    }
}
