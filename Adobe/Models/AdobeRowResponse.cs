namespace Adobe.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class AdobeRowResponse<T>
    {
        [JsonProperty("content")]
        public IEnumerable<T> Content { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("numberOfElements")]
        public int NumberOfElements { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("previousPage")]
        public bool PreviousPage { get; set; }

        [JsonProperty("firstPage")]
        public bool FirstPage { get; set; }

        [JsonProperty("nextPage")]
        public bool NextPage { get; set; }

        [JsonProperty("lastPage")]
        public bool LastPage { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}