using System;
using Newtonsoft.Json;
using FiroozehGameService.Core;

using FiroozehGameService.Models.BasicApi.Buckets;

namespace Models
{
    [Serializable]
    public class client : BucketCore
    {
        [JsonProperty("_id")]
        public string id { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }
        [JsonProperty("Pohone")]
        public int Pohone { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("shomare_shaba")]
        public string shomare_shaba { get; set; }
        [JsonProperty("shomare_hsab")]
        public string shomare_hsab { get; set; }
        [JsonProperty("cone")]
        public int cone { get; set; }

    }
}