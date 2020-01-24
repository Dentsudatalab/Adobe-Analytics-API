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

        protected AdobeAuthorizationService(AdobeClientStore adobeClientStore)
        {
            _adobeClientStore = adobeClientStore;
        }

        /// <summary>
        /// Checks whether or not the client with the given refresh token is logged in.
        /// </summary>
        /// <param name="refreshToken">The refresh token to check.</param>
        /// <returns>A bool representing the logged in state.</returns>
        public bool IsClientLoggedIn(string refreshToken = null)
        {
            return _adobeClientStore.Client != null && _adobeClientStore.Client.ExpiresAt > DateTime.Now && _adobeClientStore.Client.RefreshToken == refreshToken;
        }

        /// <summary>
        /// Returns a copy of the current client.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the client.</param>
        /// <returns>A copy of the <see cref="IdentityClient"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the client is not logged in.</exception>
        public IdentityClient GetClient(string refreshToken = null)
        {
            if (!IsClientLoggedIn(refreshToken))
                throw new InvalidOperationException(nameof(IsClientLoggedIn));

            var serializedClient = JsonConvert.SerializeObject(_adobeClientStore.Client);
            return JsonConvert.DeserializeObject<IdentityClient>(serializedClient);
        }

        /// <summary>
        /// Authorizes the client with the given <see cref="AuthValues"/>.
        /// </summary>
        /// <param name="authValues">The values to use for authorization.</param>
        public virtual async Task AuthorizeClient(AuthValues authValues)
        {
            var now = DateTime.Now;
            var client = _adobeClientStore.Client;

            var differentRefreshToken = client?.RefreshToken != authValues.Token;

            if (client == null || client.ExpiresAt < now || differentRefreshToken)
            {
                var clientInfo = await GetClientInfo(authValues);

                if (clientInfo.HasValue)
                    _adobeClientStore.Client = clientInfo.Value;
            }
        }

        protected async Task<ApiResponse<IdentityClient>> GetClientInfo(AuthValues authValues)
        {
            var clientResponse = await AdobeAuthenticationUtils.GetAccessToken(authValues);

            return clientResponse;
        }
    }
}