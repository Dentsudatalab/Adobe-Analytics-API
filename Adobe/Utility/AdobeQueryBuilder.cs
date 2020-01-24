namespace Adobe.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Extensions;

    public class AdobeQueryBuilder
    {
        private Uri BaseUri => new Uri($"https://analytics.adobe.io/api/{_companyId}/");

        private readonly string _relativePath;

        private readonly List<Field> _fields;

        private string _reportSuiteId;

        private string _companyId;

        private readonly Dictionary<string, string> _customParams;

        public AdobeQueryBuilder(string relativePath)
        {
            _relativePath = relativePath;
            _fields = new List<Field>();
            _customParams = new Dictionary<string, string>();
        }

        public AdobeQueryBuilder WithFields(IEnumerable<Field> fields)
        {
            _fields.AddRange(fields);

            return this;
        }

        public AdobeQueryBuilder WithParam(string key, string value)
        {
            _customParams[key] = value;

            return this;
        }

        public AdobeQueryBuilder WithParamIf(bool ifValue, string key, string value)
        {
            if (ifValue)
                WithParam(key, value);

            return this;
        }

        public AdobeQueryBuilder WithReportSuiteId(string id)
        {
            _reportSuiteId = id;

            return this;
        }

        public AdobeQueryBuilder WithCompanyId(string id)
        {
            _companyId = id;

            return this;
        }

        public Uri Build()
        {
            var uri = new Uri(BaseUri, _relativePath);
            var uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            // Fields
            if (_fields.Any())
            {
                var fieldString = string.Join(",", _fields);
                query["expansion"] = fieldString;
            }

            // Report suite ID
            if (!string.IsNullOrEmpty(_reportSuiteId))
            {
                query["rsid"] = _reportSuiteId;
            }

            // Custom params
            foreach (var (key, value) in _customParams)
            {
                query[key] = value;
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }
    }
}