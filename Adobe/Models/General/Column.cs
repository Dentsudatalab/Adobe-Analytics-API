namespace Adobe.Models.General
{
    using System;
    using System.Collections.Generic;

    using Enums;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public class Column
    {
        /// <summary>
        /// Gets or sets possible values include: 'DIMENSION', 'METRIC'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ColumnType Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "segmentIds")]
        public IList<string> SegmentIds { get; set; }
    }
}
