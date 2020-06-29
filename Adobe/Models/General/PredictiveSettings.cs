namespace Adobe.Models.General
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public class PredictiveSettings
    {
        [JsonProperty(PropertyName = "trainingPeriods")]
        public int? TrainingPeriods { get; set; }

        [JsonProperty(PropertyName = "highAnomalies")]
        public bool? HighAnomalies { get; set; }

        [JsonProperty(PropertyName = "lowAnomalies")]
        public bool? LowAnomalies { get; set; }
    }
}
