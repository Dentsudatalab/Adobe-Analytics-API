namespace Adobe.Utility
{
    using System;

    public class ApiException : Exception
    {
        public ApiError Error { get; }

        public ApiException(ApiError error) : base(string.Join(", ", error.Messages ?? Array.Empty<string>()))
        {
            Error = error;
        }
    }
}