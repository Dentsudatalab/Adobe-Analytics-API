namespace Adobe.Services.Authorization
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Utility;
    using Utility.Auth;

    public class AdobeAuthorizationService
    {
        private readonly AdobeClientStore _adobeClientStore;

        public AdobeAuthorizationService(AdobeClientStore adobeClientStore)
        {
            _adobeClientStore = adobeClientStore;
        }

        /// <summary>
        /// Checks whether or not the client with the given refresh token is logged in.
        /// </summary>
        /// <param name="token">The refresh token to check.</param>
        /// <returns>A bool representing the logged in state.</returns>
        public virtual bool IsClientLoggedIn(string token)
        {
            return _adobeClientStore.Client != null && _adobeClientStore.Client.ExpiresAt > DateTime.Now && _adobeClientStore.Client.RefreshToken == token;
        }

        /// <summary>
        /// Returns a copy of the current client.
        /// </summary>
        /// <param name="token">The refresh token of the client.</param>
        /// <returns>A copy of the <see cref="IdentityClient"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the client is not logged in.</exception>
        public virtual IdentityClient GetClient(string token)
        {
            if (!IsClientLoggedIn(token))
                throw new InvalidOperationException(nameof(IsClientLoggedIn));

            var serializedClient = JsonConvert.SerializeObject(_adobeClientStore.Client);
            return JsonConvert.DeserializeObject<IdentityClient>(serializedClient);
        }

        /// <summary>
        /// Authorizes the client with the given <see cref="AuthValues"/>.
        /// </summary>
        /// <param name="authValues">The values to use for authorization.</param>
        public virtual async Task<IdentityClient> AuthorizeClient(AuthValues authValues)
        {
            if (!IsClientLoggedIn(authValues.Jwt))
            {
                authValues.Jwt = JwtCreator.CreateJwt(authValues);

                var clientInfo = await GetClientInfo(authValues);

                if (clientInfo.HasValue)
                    _adobeClientStore.Client = clientInfo.Value;
            }

            return _adobeClientStore.Client;
        }

        private async Task<ApiResponse<IdentityClient>> GetClientInfo(AuthValues authValues)
        {
            var clientResponse = await AdobeAuthenticationUtils.GetAccessToken(authValues);

            return clientResponse;
        }
    }
}