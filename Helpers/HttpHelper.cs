using MovieNest.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieNest.Helpers
{
    public static class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResponseAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
        public static async Task<List<ItemModel>> FetchPhimBoDataAsync(string BaseUrl, int pages)
        {
            var allItems = new List<ItemModel>();
            for (int i = 1; i <= pages; i++)
            {
                string url = BaseUrl + i;
                string response = await HttpHelper.GetResponseAsync(url);
                if (response != null)
                {
                    var phimBoModel = JsonConvert.DeserializeObject<PhimBoModel>(response);
                    if (phimBoModel?.Data?.Items != null)
                    {
                        allItems.AddRange(phimBoModel.Data.Items);
                    }
                }
            }
            return allItems;
        }
        public static async Task<List<Item>> FetchPhimLeDataAsync(string BaseUrl, int pages)
        {
            var allItems = new List<Item>();
            for (int i = 1; i <= pages; i++)
            {
                string url = BaseUrl + i;
                string response = await HttpHelper.GetResponseAsync(url);
                if (response != null)
                {
                    var phimLeModel = JsonConvert.DeserializeObject<PhimLeModel>(response);
                    if (phimLeModel?.Data?.Items != null)
                    {
                        allItems.AddRange(phimLeModel.Data.Items);
                    }
                }
            }
            return allItems;
        }
        public static async Task<List<TrendingFilmModel>> FetchTrendingFilmAsync(string BaseUrl, int pages)
        {
            var allItems = new List<TrendingFilmModel>();
            for (int i = 1; i <= pages; i++)
            {
                string url = BaseUrl + i;
                string response = await HttpHelper.GetResponseAsync(url);
                if (response != null)
                {
                    var trendingFilm = JsonConvert.DeserializeObject<MovieResponse>(response);
                    if (trendingFilm?.Items != null)
                    {
                        allItems.AddRange(trendingFilm.Items);
                    }
                }
            }
            return allItems;
        }

        public static async Task<List<ItemHH>> FetchPhimHoatHinhDataAsync(string BaseUrl, int pages)
        {
            var allItems = new List<ItemHH>();
            for (int i = 1; i <= pages; i++)
            {
                string url = BaseUrl + i;
                string response = await HttpHelper.GetResponseAsync(url);
                if (response != null)
                {
                    var phimHoatHinhModel = JsonConvert.DeserializeObject<PhimHoatHinhModel>(response);
                    if (phimHoatHinhModel?.Data?.Items != null)
                    {
                        allItems.AddRange(phimHoatHinhModel.Data.Items);
                    }
                }
            }
            return allItems;
        }
        public static async Task<List<TvShowItem>> FetchTvShowsDataAsync(string BaseUrl, int pages)
        {
            var allItems = new List<TvShowItem>();
            for (int i = 1; i <= pages; i++)
            {
                string url = BaseUrl + i;
                string response = await HttpHelper.GetResponseAsync(url);
                if (response != null)
                {
                    var tvShowsModel = JsonConvert.DeserializeObject<TvShowsModel>(response);
                    if (tvShowsModel?.Data?.Items != null)
                    {
                        allItems.AddRange(tvShowsModel.Data.Items);
                    }
                }
            }
            return allItems;
        }
        public static async Task<List<FilmModel>> SearchAsync(string baseUrl, string keyword, int limit)
        {
            var allItems = new List<FilmModel>();
            string url = $"{baseUrl}?keyword={keyword}&limit={limit}";

            string response = await GetResponseAsync(url);
            if (response != null)
            {
                try
                {

                    var searchResponse = JsonConvert.DeserializeObject<SearchModel>(response);

                    if (searchResponse == null)
                    {
                        Console.WriteLine("Deserialization returned null for searchResponse.");
                        return allItems;
                    }

                    if (searchResponse.Data.Items == null)
                    {
                        Console.WriteLine("Deserialization returned null items.");
                        return allItems;
                    }

                    foreach (var item in searchResponse.Data.Items)
                    {
                        allItems.Add(new FilmModel
                        {
                            Name = item.Name,
                            Slug = item.Slug,
                            PosterUrl = $"https://img.phimapi.com/{item.PosterUrl}",
                        });
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Response was null.");
            }

            return allItems;
        }

    }
}
