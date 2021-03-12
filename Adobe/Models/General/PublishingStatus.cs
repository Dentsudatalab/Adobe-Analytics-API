namespace Adobe.Models.General
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public class PublishingStatus
    {
        [JsonProperty(PropertyName = "published")]
        public bool? Published { get; set; }

        [JsonProperty(PropertyName = "publishedDate")]
        public DateTime? PublishedDate { get; set; }

        [JsonProperty(PropertyName = "lookbackPeriod")]
        public int? LookbackPeriod { get; set; }

        [JsonProperty(PropertyName = "lookbackGranularity")]
        public string LookbackGranularity { get; set; }
    }
}
