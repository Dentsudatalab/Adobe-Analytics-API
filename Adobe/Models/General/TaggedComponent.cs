namespace Adobe.Models.General
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [Serializable]
    public class TaggedComponent
    {
        [JsonProperty(PropertyName = "componentType")]
        public string ComponentType { get; set; }

        [JsonProperty(PropertyName = "componentId")]
        public string ComponentId { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }
    }
}
