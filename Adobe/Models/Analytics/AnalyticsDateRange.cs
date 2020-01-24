namespace Adobe.Models.Analytics
{
    using System.Collections.Generic;
    using General;
    using Newtonsoft.Json;

    public class AnalyticsDateRange
    {
        /// <summary>
        /// Gets system generated id
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

        [JsonProperty(PropertyName = "definition")]
        public object Definition { get; set; }

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