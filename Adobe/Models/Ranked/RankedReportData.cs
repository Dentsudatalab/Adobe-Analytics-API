namespace Adobe.Models.Ranked
{
    using System;
    using System.Collections.Generic;

    using General;

    using Newtonsoft.Json;

    [Serializable]
    public class RankedReportData
    {
        [JsonProperty(PropertyName = "totalPages")]
        public int? TotalPages { get; set; }

        [JsonProperty(PropertyName = "firstPage")]
        public bool? FirstPage { get; set; }

        [JsonProperty(PropertyName = "lastPage")]
        public bool? LastPage { get; set; }

        [JsonProperty(PropertyName = "numberOfElements")]
        public int? NumberOfElements { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        [JsonProperty(PropertyName = "totalElements")]
        public int? TotalElements { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "request")]
        public RankedRequest Request { get; set; }

        [JsonProperty(PropertyName = "reportId")]
        public string ReportId { get; set; }

        [JsonProperty(PropertyName = "columns")]
        public RankedColumnMetaData Columns { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public IList<Row> Rows { get; set; }

        [JsonProperty(PropertyName = "summaryData")]
        public object SummaryData { get; set; }
    }
}
