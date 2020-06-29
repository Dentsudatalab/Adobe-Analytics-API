namespace Adobe.Models.General
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Tag Model
    /// </summary>
    [Serializable]
    public class Tag
    {
        /// <summary>
        /// Gets or sets the tag id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the tag name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of components that have been tagged with this
        /// tag
        /// </summary>
        [JsonProperty(PropertyName = "components")]
        public IList<TaggedComponent> Components { get; set; }
    }
}
