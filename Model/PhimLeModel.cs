using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MovieNest.Model
{
    public class PhimLeModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("seoOnPage")]
        public SeoOnPage SeoOnPage { get; set; }

        [JsonProperty("breadCrumb")]
        public List<BreadCrumb> BreadCrumb { get; set; }

        [JsonProperty("titlePage")]
        public string TitlePage { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("type_list")]
        public string TypeList { get; set; }

        [JsonProperty("APP_DOMAIN_FRONTEND")]
        public string AppDomainFrontend { get; set; }

        [JsonProperty("APP_DOMAIN_CDN_IMAGE")]
        public string AppDomainCdnImage { get; set; }
    }

    public class SeoOnPage
    {
        [JsonProperty("og_type")]
        public string OgType { get; set; }

        [JsonProperty("titleHead")]
        public string TitleHead { get; set; }

        [JsonProperty("descriptionHead")]
        public string DescriptionHead { get; set; }

        [JsonProperty("og_image")]
        public List<string> OgImage { get; set; }

        [JsonProperty("og_url")]
        public string OgUrl { get; set; }
    }

    public class BreadCrumb
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("isCurrent")]
        public bool IsCurrent { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }

    public class Item
    {
        [JsonProperty("modified")]
        public ModifiedPhimLe Modified { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("origin_name")]
        public string OriginName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("poster_url")]
        public string PosterUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty("sub_docquyen")]
        public bool SubDocquyen { get; set; }

        [JsonProperty("chieurap")]
        public bool Chieurap { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("episode_current")]
        public string EpisodeCurrent { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("category")]
        public List<CategoryPhimLe> Category { get; set; }

        [JsonProperty("country")]
        public List<CountryPhimLe> Country { get; set; }
    }

    public class ModifiedPhimLe
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }

    public class CategoryPhimLe
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class CountryPhimLe
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class Params
    {
        [JsonProperty("type_slug")]
        public string TypeSlug { get; set; }

        [JsonProperty("filterCategory")]
        public List<string> FilterCategory { get; set; }

        [JsonProperty("filterCountry")]
        public List<string> FilterCountry { get; set; }

        [JsonProperty("filterYear")]
        public string FilterYear { get; set; }

        [JsonProperty("filterType")]
        public string FilterType { get; set; }

        [JsonProperty("sortField")]
        public string SortField { get; set; }

        [JsonProperty("sortType")]
        public string SortType { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class Pagination
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
