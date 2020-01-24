namespace Adobe.Models.General
{
    using System.Collections.Generic;
    using Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class CalculatedMetricErrorStatus
    {
        /// <summary>
        /// Gets or sets possible values include:
        /// 'no_feature_access_to_advanced_calculated_metrics',
        /// 'invalid_metric_access', 'method_not_allowed', 'resource_conflict',
        /// 'invalid_access', 'resource_temporarily_unavailable',
        /// 'external_api_failure', 'aam_failure', 'resource_already_exists',
        /// 'invalid_state', 'invalid_json_input', 'invalid_parameters',
        /// 'invalid_dimension_access', 'unsupported_data_type',
        /// 'resource_not_found', 'insufficient_access', 'health_check_error',
        /// 'invalid_data', 'unexpected_error', 'external_api_error',
        /// 'unsupported_resource', 'io_error', 'invalid_request',
        /// 'invalid_client_id', 'unauthorized', 'authorization_error',
        /// 'invalid_token', 'insufficient_scope', 'bluecoat_unauthorized'
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorType ErrorCode { get; set; }

        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription { get; set; }

        [JsonProperty(PropertyName = "errorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "errorDetails")]
        public IDictionary<string, object> ErrorDetails { get; set; }

        [JsonProperty(PropertyName = "rootCauseService")]
        public string RootCauseService { get; set; }
    }
}