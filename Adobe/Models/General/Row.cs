namespace Adobe.Models.General
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Row
    {
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "rowId")]
        public string RowId { get; set; }

        [JsonProperty(PropertyName = "data")]
        public IList<double?> Data { get; set; }

        [JsonProperty(PropertyName = "dataExpected")]
        public IList<double?> DataExpected { get; set; }

        [JsonProperty(PropertyName = "dataUpperBound")]
        public IList<double?> DataUpperBound { get; set; }

        [JsonProperty(PropertyName = "dataLowerBound")]
        public IList<double?> DataLowerBound { get; set; }

        [JsonProperty(PropertyName = "dataAnomalyDetected")]
        public IList<bool?> DataAnomalyDetected { get; set; }

        [JsonProperty(PropertyName = "percentChange")]
        public IList<double?> PercentChange { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }
    }
}