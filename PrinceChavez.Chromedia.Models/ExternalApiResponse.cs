using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PrinceChavez.Chromedia.Models
{
    public class ExternalApiResponse : ExternalApiMetaData
    {
        public List<Article> Data { get; set; } = new List<Article>();
    }

    public class ExternalApiMetaData
    {
        public int Page { get; set; }
        public int Total { get; set; }
        
        [JsonPropertyName("per_page")]
        public int Per_Page { get; set; }
        [JsonPropertyName("total_pages")]
        public int Total_Pages { get; set; }
    }
}
