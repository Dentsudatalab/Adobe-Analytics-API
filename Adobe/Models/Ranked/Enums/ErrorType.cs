// ReSharper disable InconsistentNaming
namespace Adobe.Models.Ranked.Enums
{
    using System;

    [Serializable]
    public enum ErrorType
    {
        UNAUTHORIZED_METRIC,
        UNAUTHORIZED_DIMENSION,
        UNAUTHORIZED_DIMENSION_GLOBAL,
        ANOMALY_DETECTION_FAILURE_UNEXPECTED_ITEM_COUNT,
        ANOMALY_DETECTION_FAILURE_TSA_SERVICE,
        NOT_ENABLED_METRIC,
        NOT_ENABLED_DIMENSION,
        NOT_ENABLED_DIMENSION_GLOBAL
    }
}
