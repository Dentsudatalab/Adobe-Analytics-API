namespace Adobe.Models.General
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SegmentCompatibility
    {
        [JsonProperty(PropertyName = "valid")]
        public bool? Valid { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "validator_version")]
        public string ValidatorVersion { get; set; }

        [JsonProperty(PropertyName = "supported_products")]
        public IList<string> SupportedProducts { get; set; }

        [JsonProperty(PropertyName = "supported_schema")]
        public IList<string> SupportedSchema { get; set; }

        [JsonProperty(PropertyName = "supported_features")]
        public IList<string> SupportedFeatures { get; set; }
    }
}