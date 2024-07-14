using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieNest.Model
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
    public class Created
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }

    public class Modified
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }
    }

    public class Country
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }
    }

    public class Movie
    {
        [JsonProperty("created")]
        public Created Created { get; set; }

        [JsonProperty("modified")]
        public Modified Modified { get; set; }

        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("origin_name")]
        public string? OriginName { get; set; }

        [JsonProperty("content")]
        public string? Content { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("poster_url")]
        public string? PosterUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string? ThumbUrl { get; set; }

        [JsonProperty("is_copyright")]
        public bool IsCopyright { get; set; }

        [JsonProperty("sub_docquyen")]
        public bool SubDocquyen { get; set; }

        [JsonProperty("chieurap")]
        public bool Chieurap { get; set; }

        [JsonProperty("trailer_url")]
        public string? TrailerUrl { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        [JsonProperty("episode_current")]
        public string? EpisodeCurrent { get; set; }

        [JsonProperty("episode_total")]
        public string? EpisodeTotal { get; set; }

        [JsonProperty("quality")]
        public string? Quality { get; set; }

        [JsonProperty("lang")]
        public string? Lang { get; set; }

        [JsonProperty("notify")]
        public string? Notify { get; set; }

        [JsonProperty("showtimes")]
        public string? Showtimes { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("view")]
        public int View { get; set; }

        [JsonProperty("actor")]
        public List<string> Actor { get; set; }

        [JsonProperty("director")]
        public List<string> Director { get; set; }

        [JsonProperty("category")]
        public List<Category> Category { get; set; }

        [JsonProperty("country")]
        public List<Country> Country { get; set; }
    }

    public class ServerData
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("filename")]
        public string? Filename { get; set; }

        [JsonProperty("link_embed")]
        public string? LinkEmbed { get; set; }

        [JsonProperty("link_m3u8")]
        public string? LinkM3u8 { get; set; }

        [JsonProperty("select_episode")]
        public bool SelectEpisode { get; set; } 

        [JsonProperty("select_background")]
        public string? SelectBackground { get; set; }  
    }


    public class Episode
    {
        [JsonProperty("server_name")]
        public string? ServerName { get; set; }

        [JsonProperty("server_data")]
        public List<ServerData> ServerData { get; set; }
    }

    public class FilmDetailModel
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }

        [JsonProperty("movie")]
        public Movie Movie { get; set; }

        [JsonProperty("episodes")]
        public List<Episode> Episodes { get; set; }
    }
}
