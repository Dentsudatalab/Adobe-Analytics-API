namespace Adobe.Models.Analytics
{
    using Newtonsoft.Json;

    public class AnalyticsSegmentDeleteResponse
    {
        [JsonProperty("result")]
        public string Result { get; protected set; }
    }
}