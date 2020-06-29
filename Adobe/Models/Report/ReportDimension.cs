namespace Adobe.Models.Report
{
    using System;

    using Analytics.Enums;

    using Newtonsoft.Json;

    [Serializable]
    public class ReportDimension
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'STRING', 'INT', 'DECIMAL',
        /// 'CURRENCY', 'PERCENT', 'TIME', 'ENUM', 'ORDERED_ENUM'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(MeasureTypeConverter))]
        public MeasureType Type { get; set; }
    }
}
