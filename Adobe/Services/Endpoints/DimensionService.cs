namespace Adobe.Services.Endpoints
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Authorization;
    using Extensions;
    using Models.Analytics;
    using Utility;

    public class DimensionService : BaseAdobeService
    {
        public DimensionService(HttpClient httpClient, AdobeAuthorizationService authService) : base(httpClient, authService)
        {
        }

        /// <summary>
        /// Returns a list of dimensions for a given report suite.
        /// </summary>
        /// <param name="reportSuiteId">A Report Suite ID.</param>
        /// <param name="fields">A list of fields to return.</param>
        /// <param name="locale">Locale.</param>
        /// <param name="segmentable">Only include dimensions that are valid within a segment.</param>
        /// <param name="reportable">Only include dimensions that are valid within a report.</param>
        /// <param name="classifiable">Only include classifiable dimensions.</param>
        /// <returns>A list of dimensions for the given report suite.</returns>
        public async Task<IEnumerable<AnalyticsDimension>> GetDimensions(
            string reportSuiteId,
            IEnumerable<Field> fields,
            string locale = "en_US",
            bool segmentable = false,
            bool reportable = false,
            bool classifiable = false)
        {
            await AuthorizeClient(AuthValues);

            var uriBuilder = new AdobeQueryBuilder("dimensions")
                .WithCompanyId(AuthValues.CompanyId)
                .WithReportSuiteId(reportSuiteId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .WithParamIf(segmentable, "segmentable", "true")
                .WithParamIf(reportable, "reportable", "true")
                .WithParamIf(classifiable, "classifiable", "true");

            var uri = uriBuilder.Build();

            var response = await HttpClient.GetApiResponse<IEnumerable<AnalyticsDimension>>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }

        /// <summary>
        /// Returns a dimension for the given report suite.
        /// </summary>
        /// <param name="id">The dimension ID. For example a valid id is a value like ‘evar1’.</param>
        /// <param name="reportSuiteId">The report suite ID.</param>
        /// <param name="fields">A list of fields to return.</param>
        /// <param name="locale">The locale to use for returning system named dimensions.</param>
        /// <returns>The dimension with the given ID.</returns>
        public async Task<AnalyticsDimension> GetDimensionById(
            string id,
            string reportSuiteId,
            IEnumerable<Field> fields,
            string locale = "en_US")
        {
            await AuthorizeClient(AuthValues);

            var sanitizedId = id.Replace("variables/", string.Empty);

            var uri = new AdobeQueryBuilder($"dimensions/{sanitizedId}")
                .WithCompanyId(AuthValues.CompanyId)
                .WithReportSuiteId(reportSuiteId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .Build();

            var response = await HttpClient.GetApiResponse<AnalyticsDimension>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }
    }
}