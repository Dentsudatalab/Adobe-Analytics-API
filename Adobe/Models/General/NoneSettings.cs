namespace Adobe.Models.General
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public class NoneSettings
    {
        [JsonProperty(PropertyName = "includeNoneByDefault")]
        public bool? IncludeNoneByDefault { get; set; }

        [JsonProperty(PropertyName = "noneChangeable")]
        public bool? NoneChangeable { get; set; }
    }
}