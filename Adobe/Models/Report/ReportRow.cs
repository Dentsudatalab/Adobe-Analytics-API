namespace Adobe.Models.Report
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [Serializable]
    public class ReportRow
    {
        [JsonProperty(PropertyName = "rowId")]
        public string RowId { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public IList<string> Filters { get; set; }
    }
}
