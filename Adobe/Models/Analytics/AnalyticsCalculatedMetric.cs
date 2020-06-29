namespace Adobe.Models.Analytics
{
    using Enums;

    using General;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using System;
    using System.Collections.Generic;

    [Serializable]
    public class AnalyticsCalculatedMetric
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

        /// <summary>
        /// Gets or sets set metric polarity, which indicates whether it's good
        /// or bad if a given metric goes up. Default=positive. Possible values
        /// include: 'positive', 'negative'
        /// </summary>
        [JsonProperty(PropertyName = "polarity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PolarityType Polarity { get; set; }

        /// <summary>
        /// Gets or sets number of decimal places to include in calculated
        /// metric result
        /// </summary>
        [JsonProperty(PropertyName = "precision")]
        public int? Precision { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'CURRENCY', 'TIME',
        /// 'DECIMAL', 'PERCENT'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CalculatedMetricType Type { get; set; }

        /// <summary>
        /// Gets or sets calculated metric definition object
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public object Definition { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "siteTitle")]
        public string SiteTitle { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public System.DateTime? Modified { get; set; }

        /// <summary>
        /// Gets calculated metric creation date
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public System.DateTime? Created { get; set; }
    }
}
