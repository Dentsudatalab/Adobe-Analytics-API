namespace Adobe.Models.Analytics
{
    using System.Collections.Generic;
    using General;
    using Newtonsoft.Json;

    public class AnalyticsDateRangeDefinition
    {
        [JsonProperty(PropertyName = "start")]
        public IList<RollingDateFunction> Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public IList<RollingDateFunction> End { get; set; }

        [JsonProperty(PropertyName = "calendarType")]
        public CalendarType CalendarType { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}