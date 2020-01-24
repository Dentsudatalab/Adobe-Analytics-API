namespace Adobe.Models.General
{
    using Newtonsoft.Json;

    public class Pageable
    {
        [JsonProperty(PropertyName = "offset")]
        public int? Offset { get; set; }

        [JsonProperty(PropertyName = "sort")]
        public object Sort { get; set; }

        [JsonProperty(PropertyName = "pageNumber")]
        public int? PageNumber { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int? PageSize { get; set; }
    }
}