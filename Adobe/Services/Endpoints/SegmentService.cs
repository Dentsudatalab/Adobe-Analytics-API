namespace Adobe.Services.Endpoints
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Authorization;
    using Extensions;
    using Models.Analytics;
    using Utility;

    public class SegmentService : BaseAdobeService
    {
        public SegmentService(HttpClient httpClient, AdobeAuthorizationService authService) : base(httpClient, authService)
        {
        }

        /// <summary>
        /// Retrieves all segments.
        /// </summary>
        /// <param name="reportSuiteId">Filter list to only include segments tied to specified RSID list (comma-delimited).</param>
        /// <param name="rsids">Filter list to only include suites in this RSID list.</param>
        /// <param name="segmentFilter">Filter list to only include segments in the specified list.</param>
        /// <param name="name">Filter list to only include segments that contains the Name.</param>
        /// <param name="locale">Locale.</param>
        /// <param name="tagNames">Filter list to only include segments that contains one of the tags.</param>
        /// <param name="filterByPublishedSegments">Filter list to only include segments where the published field is set to one of the allowable values (all, true, false).</param>
        /// <param name="sortDirection">Sort direction (ASC or DESC).</param>
        /// <param name="sortProperty">Property to sort by (name, modified_date, id is currently allowed).</param>
        /// <returns></returns>
        public async Task<IEnumerable<AnalyticsSegmentResponseItem>> GetSegments(
            string reportSuiteId,
            IEnumerable<Field> fields,
            IEnumerable<string> segmentFilter = null,
            string name = "",
            string locale = "en_US",
            IEnumerable<string> tagNames = null,
            string filterByPublishedSegments = "all",
            string sortDirection = "ASC",
            string sortProperty = "id")
        {
            await AuthorizeClient(AuthValues);

            segmentFilter = segmentFilter ?? Array.Empty<string>();
            tagNames = tagNames ?? Array.Empty<string>();

            var query = new AdobeQueryBuilder("segments")
                .WithCompanyId(AuthValues.CompanyId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .WithParam("name", name)
                .WithParam("includeType", "all")
                .WithParam("sortDirection", sortDirection)
                .WithParam("sortProperty", sortProperty)
                .WithParam("filterByPublishedSegments", filterByPublishedSegments)
                .WithParamIf(segmentFilter != null, "segmentFilter", string.Join(",", segmentFilter))
                .WithParamIf(tagNames != null, "tagNames", string.Join(",", tagNames));

            var segments = await GetAllPagesFromApi<AnalyticsSegmentResponseItem>(query);

            return segments;
        }

        /// <summary>
        /// Creates segment.
        /// </summary>
        /// <param name="segment">The segment to create</param>
        /// <param name="fields">The fields to include from response.</param>
        /// <param name="locale">Locale.</param>
        /// <returns>The created segment.</returns>
        public virtual async Task<AnalyticsSegmentResponseItem> CreateSegment(AnalyticsSegmentResponseItem segment, IEnumerable<Field> fields, string locale = "en_US")
        {
            await AuthorizeClient(AuthValues);

            var uri = new AdobeQueryBuilder("segments")
                .WithCompanyId(AuthValues.CompanyId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .Build();

            var response = await HttpClient.PostApiResponse<AnalyticsSegmentResponseItem>(uri, segment);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }

        /// <summary>
        /// Update a segment.
        /// </summary>
        /// <param name="segment">The segment to update</param>
        /// <param name="fields">The fields to include from response.</param>
        /// <param name="locale">Locale.</param>
        /// <returns>The updated segment.</returns>
        public async Task<AnalyticsSegmentResponseItem> UpdateSegment(AnalyticsSegmentResponseItem segment, IEnumerable<Field> fields, string locale = "en_US")
        {
            await AuthorizeClient(AuthValues);

            var uri = new AdobeQueryBuilder($"segments/{segment.Id}")
                .WithCompanyId(AuthValues.CompanyId)
                .WithFields(fields)
                .WithParam("locale", locale)
                .Build();

            var response = await HttpClient.PutApiResponse<AnalyticsSegmentResponseItem>(uri, segment);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }

        /// <summary>
        /// Delete a segment.
        /// </summary>
        /// <param name="segmentId">The ID of the segment to delete.</param>
        /// <param name="locale">Locale.</param>
        /// <returns>The result of the delete action.</returns>
        public virtual async Task<AnalyticsSegmentDeleteResponse> DeleteSegment(string segmentId, string locale = "en_US")
        {
            await AuthorizeClient(AuthValues);

            var uri = new AdobeQueryBuilder($"segments/{segmentId}")
                .WithCompanyId(AuthValues.CompanyId)
                .WithParam("locale", locale)
                .Build();

            var response = await HttpClient.DeleteApiResponse<AnalyticsSegmentDeleteResponse>(uri);

            if (response != null && response.HasValue)
                return response.Value;

            throw new ApiException(response?.Error);
        }
    }
}