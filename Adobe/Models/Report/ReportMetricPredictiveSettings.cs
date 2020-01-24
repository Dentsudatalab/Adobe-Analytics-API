namespace Adobe.Models.Report
{
    using Newtonsoft.Json;

    public class ReportMetricPredictiveSettings
    {
        [JsonProperty(PropertyName = "anomalyConfidence")]
        public double? AnomalyConfidence { get; set; }
    }
}