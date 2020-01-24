namespace Adobe.Utility
{
    using Newtonsoft.Json;

    public class ApiError
    {
        [JsonProperty("messages")]
        public string[] Messages { get; set; }

        [JsonProperty("developerMessage")]
        public object DeveloperMessage { get; set; }

        [JsonProperty("errorDescription")]
        private string ErrorDescription
        {
            set => Messages = new[] { value };
        }

        [JsonProperty("errorCode")]
        private string ErrorCode
        {
            set => DeveloperMessage = value;
        }
    }
}