namespace Adobe.Models.Ranked
{
    using System;
    using Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public class RankedColumnError
    {
        [JsonProperty(PropertyName = "columnId")]
        public string ColumnId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'unauthorized_metric',
        /// 'unauthorized_dimension', 'unauthorized_dimension_global',
        /// 'anomaly_detection_failure_unexpected_item_count',
        /// 'anomaly_detection_failure_tsa_service', 'not_enabled_metric',
        /// 'not_enabled_dimension', 'not_enabled_dimension_global'
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorType ErrorCode { get; set; }

        [JsonProperty(PropertyName = "errorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription { get; set; }
    }
}