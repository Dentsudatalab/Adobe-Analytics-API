namespace Adobe.Services.Endpoints
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Authorization;

    using Extensions;

    using Models;
    using Models.Analytics;

    using Utility;

    public class UserService : BaseAdobeService
    {
        public UserService(HttpClient httpClient, AdobeAuthorizationService authService) : base(httpClient, authService)
        {
        }

        /// <summary>
        /// Returns a list of users for the current user's login company.
        /// </summary>
        /// <returns>A list of users.</returns>
        public async Task<IEnumerable<AnalyticsUser>> GetUsers()
        {
            await AuthorizeClient(AuthValues);

            var query = new AdobeQueryBuilder("users");
            var users = await GetAllPagesFromApi<AnalyticsUser>(query);

            return users;
        }

        /// <summary>
        /// Get the current user.
        /// </summary>
        /// <returns>The current user.</returns>
        public async Task<AnalyticsUser> GetMe()
        {
            await AuthorizeClient(AuthValues);

            var uri = new Uri(BaseUri, "users/me");

            var user = await HttpClient.GetApiResponse<AnalyticsUser>(uri);

            if (user != null && user.HasValue)
                return user.Value;

            throw new ApiException(user?.Error);
        }
    }
}
