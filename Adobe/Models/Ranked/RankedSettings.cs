namespace Adobe.Models.Ranked
{
    using Newtonsoft.Json;

    public class RankedSettings
    {
        [JsonProperty(PropertyName = "limit")]
        public int? Limit { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int? Page { get; set; }

        [JsonProperty(PropertyName = "dimensionSort")]
        public string DimensionSort { get; set; }

        [JsonProperty(PropertyName = "countRepeatInstances")]
        public bool? CountRepeatInstances { get; set; }

        [JsonProperty(PropertyName = "reflectRequest")]
        public bool? ReflectRequest { get; set; }

        [JsonProperty(PropertyName = "includeAnomalyDetection")]
        public bool? IncludeAnomalyDetection { get; set; }

        [JsonProperty(PropertyName = "includePercentChange")]
        public bool? IncludePercentChange { get; set; }

        [JsonProperty(PropertyName = "includeLatLong")]
        public bool? IncludeLatLong { get; set; }

        [JsonProperty(PropertyName = "nonesBehavior")]
        public string NonesBehavior { get; set; }
    }
}