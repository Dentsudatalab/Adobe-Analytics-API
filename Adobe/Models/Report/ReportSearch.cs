namespace Adobe.Models.Report
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [Serializable]
    public class ReportSearch
    {
        [JsonProperty(PropertyName = "clause")]
        public string Clause { get; set; }

        [JsonProperty(PropertyName = "excludeItemIds")]
        public IList<string> ExcludeItemIds { get; set; }

        [JsonProperty(PropertyName = "itemIds")]
        public IList<string> ItemIds { get; set; }

        [JsonProperty(PropertyName = "includeSearchTotal")]
        public bool? IncludeSearchTotal { get; set; }

        [JsonProperty(PropertyName = "empty")]
        public bool? Empty { get; set; }
    }
}
