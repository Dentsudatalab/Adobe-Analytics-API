namespace Adobe.Utility.Auth
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Extensions;

    public static class AdobeAuthenticationUtils
    {
        private const string ExchangeJwtUrl = "https://ims-na1.adobelogin.com/ims/exchange/jwt/";

        /// <summary>
        /// Exchanges a JWT for an access token.
        /// </summary>
        /// <param name="authValues">The auth values to use.</param>
        /// <returns>An <see cref="IdentityClient"/>.</returns>
        public static async Task<ApiResponse<IdentityClient>> GetAccessToken(AuthValues authValues)
        {
            using (var client = new HttpClient())
            {
                var requestParams = new Dictionary<string, string>
                {
                    { "client_id", authValues.ClientId },
                    { "client_secret", authValues.ClientSecret },
                    { "jwt_token", authValues.Token }
                };

                var result = await client.PostFormResponse<IdentityClient>(ExchangeJwtUrl, requestParams);
                return result;
            }
        }
    }
}