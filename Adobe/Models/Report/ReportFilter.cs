namespace Adobe.Models.Report
{
    using System.Collections.Generic;
    using Enums;
    using Newtonsoft.Json;

    public class ReportFilter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'DATE_RANGE', 'BREAKDOWN',
        /// 'SEGMENT', 'EXCLUDE_ITEM_IDS'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(ReportFilterTypeConverter))]
        public ReportFilterType Type { get; set; }

        [JsonProperty(PropertyName = "dimension")]
        public string Dimension { get; set; }

        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "itemIds")]
        public IList<string> ItemIds { get; set; }

        [JsonProperty(PropertyName = "segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty(PropertyName = "segmentDefinition")]
        public IDictionary<string, object> SegmentDefinition { get; set; }

        [JsonProperty(PropertyName = "dateRange")]
        public string DateRange { get; set; }

        [JsonProperty(PropertyName = "excludeItemIds")]
        public IList<string> ExcludeItemIds { get; set; }
    }
}