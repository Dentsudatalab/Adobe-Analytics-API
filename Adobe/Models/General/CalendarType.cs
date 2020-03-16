namespace Adobe.Models.General
{
    using System;
    using Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public class CalendarType
    {
        [JsonProperty(PropertyName = "rsid")]
        public string Rsid { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'gregorian', 'nrf', 'qrs',
        /// 'custom_454', 'custom_445', 'modified_gregorian'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CalendarValueType Type { get; set; }

        [JsonProperty(PropertyName = "anchorDate")]
        public System.DateTime? AnchorDate { get; set; }
    }
}