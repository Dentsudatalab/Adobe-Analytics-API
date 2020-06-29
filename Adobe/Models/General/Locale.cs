namespace Adobe.Models.General
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [Serializable]
    public class Locale
    {
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "script")]
        public string Script { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "variant")]
        public string Variant { get; set; }

        [JsonProperty(PropertyName = "extensionKeys")]
        public IList<string> ExtensionKeys { get; set; }

        [JsonProperty(PropertyName = "unicodeLocaleAttributes")]
        public IList<string> UnicodeLocaleAttributes { get; set; }

        [JsonProperty(PropertyName = "unicodeLocaleKeys")]
        public IList<string> UnicodeLocaleKeys { get; set; }

        [JsonProperty(PropertyName = "iso3Language")]
        public string Iso3Language { get; set; }

        [JsonProperty(PropertyName = "iso3Country")]
        public string Iso3Country { get; set; }

        [JsonProperty(PropertyName = "displayLanguage")]
        public string DisplayLanguage { get; set; }

        [JsonProperty(PropertyName = "displayScript")]
        public string DisplayScript { get; set; }

        [JsonProperty(PropertyName = "displayCountry")]
        public string DisplayCountry { get; set; }

        [JsonProperty(PropertyName = "displayVariant")]
        public string DisplayVariant { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }
    }
}
