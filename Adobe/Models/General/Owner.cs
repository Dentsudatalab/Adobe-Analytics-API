namespace Adobe.Models.General
{
    using Newtonsoft.Json;

    public class Owner
    {
        /// <summary>
        /// Gets or sets the login id of the owner
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}