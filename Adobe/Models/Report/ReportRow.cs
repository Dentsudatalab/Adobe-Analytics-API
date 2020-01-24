namespace Adobe.Models.Report
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReportRow
    {
        [JsonProperty(PropertyName = "rowId")]
        public string RowId { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public IList<string> Filters { get; set; }
    }
}