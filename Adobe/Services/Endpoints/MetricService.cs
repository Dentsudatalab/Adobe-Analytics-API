namespace Adobe.Services.Endpoints
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Authorization;
    using Extensions;
    using Models.Analytics;
    using Utility;

    public class MetricService : BaseAdobeService
    {
        public MetricService(HttpClient httpClient, AdobeAuthorizationService authService) : base(httpClient, authService)
        {
        }

        /// <summary>
        /// Returns a list of metrics for the given report suite.
        /// </summary>
        /// <param name="reportSuiteId">ID of desired report suite ie. sistr2.</param>
        /// <param name="fields">A list of fields to return.</param>
        /// <param name="locale">Locale that system named metrics should be returned in</param>
        /// <param name="segmentable">Filter the metrics by if they are valid in a segment.</param>
        /// <returns>A list of metrics for the given report suite.</returns>
        public virtual async Task<IEnumerable<AnalyticsMetric>> GetMetrics(string reportSuiteId, IEnumerable<Field> fields, string locale = "en_US", bool segmentable = false)
        {
            await AuthorizeClient(AuthValues);

            var uri = new AdobeQueryBuilder("metrics")
                .WithCompanyId(AuthValues.CompanyId)
                .WithReportSuiteId(reportSuiteId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .WithParam("segmentable", segmentable.ToString().ToLowerInvariant())
                .Build();

            var response = await HttpClient.GetApiResponse<IEnumerable<AnalyticsMetric>>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }

        /// <summary>
        /// Returns a metric for the given report suite.
        /// </summary>
        /// <param name="id">The id of the metric for which to retrieve info. Note ids are values like pageviews, not metrics/pageviews.</param>
        /// <param name="reportSuiteId">ID of desired report suite ie. sistr2.</param>
        /// <param name="fields">A list of fields to return.</param>
        /// <param name="locale">Locale that system named metrics should be returned in.</param>
        /// <returns>The metric with the given ID.</returns>
        public async Task<AnalyticsMetric> GetMetricById(
            string id,
            string reportSuiteId,
            IEnumerable<Field> fields,
            string locale = "en_US")
        {
            await AuthorizeClient(AuthValues);

            var sanitizedId = id.Replace("metrics/", string.Empty);

            var uri = new AdobeQueryBuilder($"metrics/{sanitizedId}")
                .WithCompanyId(AuthValues.CompanyId)
                .WithReportSuiteId(reportSuiteId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .Build();

            var response = await HttpClient.GetApiResponse<AnalyticsMetric>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }
    }
}