namespace Adobe.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Authorization;
    using Extensions;
    using Models;
    using Utility;
    using Utility.Auth;

    public abstract class BaseAdobeService
    {
        protected Uri BaseUri => new Uri($"https://analytics.adobe.io/api/{AuthValues.CompanyId}/");

        protected HttpClient HttpClient { get; }

        protected AdobeAuthorizationService AuthService { get; }

        protected AuthValues AuthValues;

        protected BaseAdobeService(HttpClient httpClient, AdobeAuthorizationService authService)
        {
            HttpClient = httpClient;
            AuthService = authService;
        }

        /// <summary>
        /// Sets the auth values for the service to use.
        /// </summary>
        /// <param name="authValues">The auth values.</param>
        public void SetAuthValues(AuthValues authValues)
        {
            AuthValues = authValues;
        }

        protected async Task AuthorizeClient(AuthValues authValues)
        {
            if (!AuthService.IsClientLoggedIn())
            {
                var jwt = JwtCreator.CreateJwt(authValues);

                var baseAuthValues = new AuthValues
                {
                    ClientId = authValues.ClientId,
                    ClientSecret = authValues.ClientSecret,
                    Token = jwt
                };

                await AuthService.AuthorizeClient(baseAuthValues);
            }

            var client = AuthService.GetClient();

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", client.AccessToken);

            HttpClient.DefaultRequestHeaders.Set("x-proxy-global-company-id", authValues.CompanyId);
            HttpClient.DefaultRequestHeaders.Set("x-api-key", authValues.ClientId);
        }

        protected async Task<IEnumerable<TItem>> GetAllPagesFromApi<TItem>(AdobeQueryBuilder query, int pageSize = 1000)
        {
            var items = new List<TItem>();

            var page = 0;
            ApiResponse<AdobeRowResponse<TItem>> response;
            do
            {
                var uri = query
                    .WithParam("limit", pageSize.ToString())
                    .WithParam("page", page.ToString())
                    .Build();

                response = await HttpClient.GetApiResponse<AdobeRowResponse<TItem>>(uri);

                if (response == null || !response.HasValue)
                    throw new ApiException(response?.Error);

                items.AddRange(response.Value.Content);
                page++;
            } while (response.Value.TotalElements > 0 && !response.Value.LastPage);

            return items;
        }
    }
}