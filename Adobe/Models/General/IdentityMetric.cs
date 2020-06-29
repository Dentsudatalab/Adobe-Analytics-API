namespace Adobe.Models.General
{
    using System;

    using Enums;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [Serializable]
    public class IdentityMetric
    {
        [JsonProperty(PropertyName = "identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'LINEAR_ALLOCATION',
        /// 'PARTICIPATION_ALLOCATION', 'LAST_TOUCH_ALLOCATION',
        /// 'MC_FIRST_TOUCH_ALLOCATION', 'MC_LAST_TOUCH_ALLOCATION'
        /// </summary>
        [JsonProperty(PropertyName = "dimensionView")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DimensionViewType DimensionView { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'ALLOCATION_FIRST_TOUCH',
        /// 'ALLOCATION_LAST_TOUCH', 'ALLOCATION_INSTANCE',
        /// 'ALLOCATION_DEDUPED_INSTANCE', 'ALLOCATION_LAST_KNOWN',
        /// 'ALLOCATION_LEGACY', 'ALLOCATION_LINEAR',
        /// 'ALLOCATION_PARTICIPATION', 'ALLOCATION_POSITION_BASED',
        /// 'ALLOCATION_TIME_DECAY', 'ALLOCATION_U_SHAPED',
        /// 'ALLOCATION_J_SHAPED', 'ALLOCATION_REVERSE_J_SHAPED'
        /// </summary>
        [JsonProperty(PropertyName = "allocationModel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AllocationModelType AllocationModel { get; set; }
    }
}
