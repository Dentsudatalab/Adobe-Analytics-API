namespace Adobe.Models.General
{
    using Newtonsoft.Json;

    public class RowItem
    {
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}