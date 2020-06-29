namespace Adobe.Models.Ranked
{
    using System;
    using System.Collections.Generic;

    using General;

    using Newtonsoft.Json;

    using Report;

    [Serializable]
    public class RankedRequest
    {
        [JsonProperty(PropertyName = "rsid")]
        public string Rsid { get; set; }

        [JsonProperty(PropertyName = "dimension")]
        public string Dimension { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public Locale Locale { get; set; }

        [JsonProperty(PropertyName = "globalFilters")]
        public IList<ReportFilter> GlobalFilters { get; set; }

        [JsonProperty(PropertyName = "search")]
        public ReportSearch Search { get; set; }

        [JsonProperty(PropertyName = "settings")]
        public RankedSettings Settings { get; set; }

        [JsonProperty(PropertyName = "statistics")]
        public RankedStatistics Statistics { get; set; }

        [JsonProperty(PropertyName = "metricContainer")]
        public ReportMetrics MetricContainer { get; set; }

        [JsonProperty(PropertyName = "rowContainer")]
        public ReportRows RowContainer { get; set; }

        [JsonProperty(PropertyName = "anchorDate")]
        public string AnchorDate { get; set; }
    }
}
