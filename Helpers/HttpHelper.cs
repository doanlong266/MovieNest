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
    }
}
