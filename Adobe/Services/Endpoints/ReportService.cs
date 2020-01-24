namespace Adobe.Services.Endpoints
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Authorization;
    using Extensions;
    using Models.Ranked;
    using Utility;

    public class ReportService : BaseAdobeService
    {
        public ReportService(HttpClient httpClient, AdobeAuthorizationService authService) : base(httpClient, authService)
        {
        }

        /// <summary>
        /// Runs a report for the request in the post body.
        /// </summary>
        /// <param name="body">The report request.</param>
        /// <returns>The report response.</returns>
        public async Task<RankedReportData> PostReport(RankedRequest body)
        {
            await AuthorizeClient(AuthValues);

            var uri = new Uri(BaseUri, "reports");

            var response = await HttpClient.PostApiResponse<RankedReportData>(uri, body);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }
    }
}