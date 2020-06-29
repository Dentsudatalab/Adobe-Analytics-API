namespace Adobe.Utility.Auth
{
    using System;
    using System.Text;

    using Newtonsoft.Json;

    [Serializable]
    public class IdentityClient
    {
        private int _expiresIn;

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn
        {
            get => _expiresIn;
            set
            {
                _expiresIn = value;
                ExpiresAt = DateTime.Now.AddSeconds(value);
            }
        }

        [JsonIgnore]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        public IdentityId GetId()
        {
            if (string.IsNullOrEmpty(IdToken))
                return null;

            var splitIdentity = IdToken.Split('.');

            var id = JsonConvert.DeserializeObject<IdentityId>(Decode(splitIdentity[1]));

            return id;
        }

        private static string Decode(string input)
        {
            while (input.Length % 4 != 0)
                input += "=";

            var converted = Convert.FromBase64String(input);

            return Encoding.UTF8.GetString(converted);
        }
    }
}
