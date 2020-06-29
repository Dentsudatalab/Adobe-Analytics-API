namespace Adobe.Services.Endpoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Authorization;

    using Extensions;

    using Models;
    using Models.General;

    using Utility;

    public class ReportSuiteService : BaseAdobeService
    {
        public ReportSuiteService(HttpClient httpClient, AdobeAuthorizationService authService) : base(
            httpClient,
            authService)
        {
        }

        /// <summary>
        /// Retrieves report suites that match the given filters.
        /// </summary>
        /// <param name="fields">A list of fields to return.</param>
        /// <param name="rsids">Filter list to only include suites in this RSID list.</param>
        /// <param name="rsidContains">Filter list to only include suites whose rsid contains rsidContains.</param>
        /// <returns>A list of report suites.</returns>
        public async Task<IEnumerable<SuiteCollectionItem>> GetReportSuites(
            IEnumerable<Field> fields,
            IEnumerable<string> rsids = null,
            string rsidContains = null)
        {
            await AuthorizeClient(AuthValues);

            rsids = rsids ?? Array.Empty<string>();

            var query = new AdobeQueryBuilder("collections/suites")
                .WithCompanyId(AuthValues.CompanyId)
                .WithFields(fields)
                .WithParamIf(rsids.Any(), "rsids", string.Join(",", rsids))
                .WithParamIf(!string.IsNullOrEmpty(rsidContains), "rsidContains", rsidContains);

            var reportSuites = await GetAllPagesFromApi<SuiteCollectionItem>(query);

            return reportSuites;
        }

        /// <summary>
        /// Retrieves report suite by id.
        /// </summary>
        /// <param name="id">The rsid of the suite to return.</param>
        /// <param name="fields">A list of fields to return.</param>
        /// <returns>The report suite with the given ID.</returns>
        public async Task<SuiteCollectionItem> GetReportSuiteById(string id, IEnumerable<Field> fields)
        {
            await AuthorizeClient(AuthValues);

            var uri = new AdobeQueryBuilder($"collections/suites/{id}")
                .WithCompanyId(AuthValues.CompanyId)
                .WithFields(fields)
                .Build();

            var response = await HttpClient.GetApiResponse<SuiteCollectionItem>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }
    }
}
