namespace Adobe.Models.Ranked
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using Report;

    [Serializable]
    public class RankedColumnMetaData
    {
        [JsonProperty(PropertyName = "dimension")]
        public ReportDimension Dimension { get; set; }

        [JsonProperty(PropertyName = "columnIds")]
        public IList<string> ColumnIds { get; set; }

        [JsonProperty(PropertyName = "columnErrors")]
        public IList<RankedColumnError> ColumnErrors { get; set; }
    }
}
