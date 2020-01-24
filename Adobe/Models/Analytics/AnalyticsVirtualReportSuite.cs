namespace Adobe.Models.Analytics
{
    using System.Collections.Generic;
    using General;
    using Newtonsoft.Json;

    public class AnalyticsVirtualReportSuite
    {
        /// <summary>
        /// Gets or sets system generated virtual report suite id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the report suite id for which the component was
        /// created/updated
        /// </summary>
        [JsonProperty(PropertyName = "rsid")]
        public string Rsid { get; set; }

        /// <summary>
        /// Gets the report suite name for which the component was
        /// created/updated
        /// </summary>
        [JsonProperty(PropertyName = "reportSuiteName")]
        public string ReportSuiteName { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// Gets or sets parent report suite id for virtual report suite
        /// </summary>
        [JsonProperty(PropertyName = "parentRsid")]
        public string ParentRsid { get; set; }

        /// <summary>
        /// Gets or sets parent report suite name
        /// </summary>
        [JsonProperty(PropertyName = "parentRsidName")]
        public string ParentRsidName { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public int? Timezone { get; set; }

        /// <summary>
        /// Gets or sets list of segments applied to this virtual report suite
        /// </summary>
        [JsonProperty(PropertyName = "segmentList")]
        public IList<string> SegmentList { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "calendarType")]
        public CalendarType CalendarType { get; set; }

        /// <summary>
        /// Gets or sets suite friendly timezone name
        /// </summary>
        [JsonProperty(PropertyName = "timezoneZoneInfo")]
        public string TimezoneZoneInfo { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "siteTitle")]
        public string SiteTitle { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public System.DateTime? Modified { get; set; }

        [JsonProperty(PropertyName = "created")]
        public System.DateTime? Created { get; set; }
    }
}