namespace Adobe.Models.General
{
    using Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class RollingDateFunction
    {
        [JsonProperty(PropertyName = "function")]
        public string Function { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'year', 'quarter', 'month',
        /// 'week', 'day', 'hour', 'minute'
        /// </summary>
        [JsonProperty(PropertyName = "granularity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GranularityType Granularity { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'monday', 'tuesday',
        /// 'wednesday', 'thursday', 'friday', 'saturday', 'sunday'
        /// </summary>
        [JsonProperty(PropertyName = "dow")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DayOfWeek Dow { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
    }
}