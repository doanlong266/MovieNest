using Newtonsoft.Json;

namespace MovieNest.Model
{
    public class TrendingFilmModel
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("origin_name")]
        public string? OriginName { get; set; }

        [JsonProperty("poster_url")]
        public string? PosterUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string? ThumbUrl { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("modified")]
        public ModifiedTime? Modified { get; set; }
    }

    public class ModifiedTime
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }

    public class MovieResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("items")]
        public List<TrendingFilmModel>? Items { get; set; }

        [JsonProperty("pagination")]
        public PaginationTrending? Pagination { get; set; }
    }


    public class PaginationTrending
    {
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("totalItemsPerPage")]
        public int TotalItemsPerPage { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}
