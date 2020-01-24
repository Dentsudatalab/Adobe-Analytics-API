namespace Adobe.Models.Report
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReportMetric
    {
        public static ReportMetric Visits => new ReportMetric("metrics/visits");

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "columnId")]
        public string ColumnId { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public IList<string> Filters { get; set; }

        [JsonProperty(PropertyName = "sort")]
        public string Sort { get; set; }

        [JsonProperty(PropertyName = "metricDefinition")]
        public IDictionary<string, object> MetricDefinition { get; set; }

        [JsonProperty(PropertyName = "predictive")]
        public ReportMetricPredictiveSettings Predictive { get; set; }

        public ReportMetric()
        {
        }

        public ReportMetric(string id)
        {
            Id = id;
            ColumnId = id;
        }

        protected bool Equals(ReportMetric other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReportMetric)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public static bool operator ==(ReportMetric left, ReportMetric right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReportMetric left, ReportMetric right)
        {
            return !Equals(left, right);
        }
    }
}