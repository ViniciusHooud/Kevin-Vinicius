using System;
using Newtonsoft.Json;
using MobileCamoes.Infra;
using System.Collections;
using System.Collections.Generic;

namespace MobileCamoes.Model
{
    public class Serie: DBEntity
    {
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_air_date")]
        public DateTimeOffset FirstAirDate { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenrersId { get; set; }

        [JsonIgnore]
        public string ReleaseDate { get { return $"{FirstAirDate:dd/MM/yy}"; } }

        [JsonIgnore]
        public string Poster { get { return $"{AppSettings.ApiImageBaseUrl}{PosterPath}"; } }

        [JsonIgnore]
        public string BackDrop { get { return $"{AppSettings.ApiImageBaseUrl}{BackdropPath}"; } }

        [JsonIgnore]
        public List<Genrer> Genrers { get; set; }

        [JsonIgnore]
        public string Genres { get => string.Join(" | ", Genrers); }
    }

}

