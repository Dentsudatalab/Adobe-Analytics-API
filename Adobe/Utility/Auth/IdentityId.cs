namespace Adobe.Utility.Auth
{
    using Newtonsoft.Json;

    public class IdentityId
    {
        [JsonProperty("iss")]
        public string Issuer { get; set; }

        [JsonProperty("azp")]
        public string AuthorizedPresenter { get; set; }

        [JsonProperty("aud")]
        public string Audience { get; set; }

        [JsonProperty("sub")]
        public string Sub { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("at_hash")]
        public string AccessTokenHash { get; set; }

        [JsonProperty("iat")]
        public int IssuedAt { get; set; }

        [JsonProperty("exp")]
        public int ExpiresAt { get; set; }
    }
}
