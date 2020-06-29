namespace Adobe.Utility
{
    public class ApiResponse<T>
    {
        public T Value { get; }

        public bool HasValue => Value != null;

        public ApiError Error { get; set; }

        public ApiResponse(T value)
        {
            Value = value;
        }

        public ApiResponse(ApiError error)
        {
            Error = error;
        }
    }
}
