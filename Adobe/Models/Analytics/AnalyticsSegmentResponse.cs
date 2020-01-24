namespace Adobe.Models.Analytics
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AnalyticsSegmentResponse
    {
        public static readonly AnalyticsSegmentResponseItemFields Fields = new AnalyticsSegmentResponseItemFields();

        [JsonProperty(PropertyName = "content")]
        public IEnumerable<AnalyticsSegmentResponseItem> Content { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int? TotalPages { get; set; }

        [JsonProperty(PropertyName = "firstPage")]
        public bool? FirstPage { get; set; }

        [JsonProperty(PropertyName = "lastPage")]
        public bool? LastPage { get; set; }

        [JsonProperty(PropertyName = "numberOfElements")]
        public int? NumberOfElements { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int? Size { get; set; }

        [JsonProperty(PropertyName = "totalElements")]
        public int? TotalElements { get; set; }
    }
}