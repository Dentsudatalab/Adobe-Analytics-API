namespace Adobe.Models.Report
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReportRows
    {
        [JsonProperty(PropertyName = "rowFilters")]
        public IList<ReportFilter> RowFilters { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public IList<ReportRow> Rows { get; set; }
    }
}