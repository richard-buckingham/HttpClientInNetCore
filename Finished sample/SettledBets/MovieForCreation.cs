using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettledBets
{
    public class MovieForCreation
    {
        [JsonProperty("title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("genre", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty("releaseDate", Required = Required.Always)]
        public System.DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("directorId", Required = Required.Always)]
        public System.Guid DirectorId { get; set; }
    }
}
