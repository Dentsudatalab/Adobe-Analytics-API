namespace Adobe.Models.General
{
    using Newtonsoft.Json;

    public class PublishingStatus
    {
        [JsonProperty(PropertyName = "published")]
        public bool? Published { get; set; }

        [JsonProperty(PropertyName = "publishedDate")]
        public System.DateTime? PublishedDate { get; set; }

        [JsonProperty(PropertyName = "lookbackPeriod")]
        public int? LookbackPeriod { get; set; }

        [JsonProperty(PropertyName = "lookbackGranularity")]
        public string LookbackGranularity { get; set; }
    }
}