namespace Adobe.Models.General
{
    using Newtonsoft.Json;

    public class NoneSettings
    {
        [JsonProperty(PropertyName = "includeNoneByDefault")]
        public bool? IncludeNoneByDefault { get; set; }

        [JsonProperty(PropertyName = "noneChangeable")]
        public bool? NoneChangeable { get; set; }
    }
}