namespace Adobe.Models.Analytics
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public class AnalyticsSegmentDeleteResponse
    {
        [JsonProperty("result")]
        public string Result { get; protected set; }
    }
}
