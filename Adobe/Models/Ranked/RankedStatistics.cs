namespace Adobe.Models.Ranked
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RankedStatistics
    {
        [JsonProperty(PropertyName = "functions")]
        public IList<string> Functions { get; set; }

        [JsonProperty(PropertyName = "ignoreZeroes")]
        public bool? IgnoreZeroes { get; set; }
    }
}