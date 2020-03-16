namespace Adobe.Models.Report
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public class ReportMetricPredictiveSettings
    {
        [JsonProperty(PropertyName = "anomalyConfidence")]
        public double? AnomalyConfidence { get; set; }
    }
}