namespace Adobe.Models.General
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [Serializable]
    public class CalcMetricCompatibility
    {
        [JsonProperty(PropertyName = "valid")]
        public bool? Valid { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "identityMetrics")]
        public IList<IdentityMetric> IdentityMetrics { get; set; }

        [JsonProperty(PropertyName = "identityDimensions")]
        public IList<string> IdentityDimensions { get; set; }

        [JsonProperty(PropertyName = "segments")]
        public IList<string> Segments { get; set; }

        [JsonProperty(PropertyName = "functions")]
        public IList<string> Functions { get; set; }

        [JsonProperty(PropertyName = "validator_version")]
        public string ValidatorVersion { get; set; }

        [JsonProperty(PropertyName = "supported_products")]
        public IList<string> SupportedProducts { get; set; }

        [JsonProperty(PropertyName = "supported_schema")]
        public IList<string> SupportedSchema { get; set; }
    }
}
