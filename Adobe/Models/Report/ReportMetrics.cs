namespace Adobe.Models.Report
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class ReportMetrics
    {
        [JsonProperty(PropertyName = "metricFilters")]
        public IList<ReportFilter> MetricFilters { get; set; }

        [JsonProperty(PropertyName = "metrics")]
        public IList<ReportMetric> Metrics { get; set; }
    }
}