namespace Adobe.Models.General
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public class RowItem
    {
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
