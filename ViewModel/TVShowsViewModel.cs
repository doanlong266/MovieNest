using MovieNest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNest.ViewModel
{
    public class TVShowsViewModel
    {
        public readonly string url = "https://phimapi.com/v1/api/danh-sach/tv-shows?page=";

        public async Task<List<TvShowItem>> FetchTvShowsDataAsync()
        {
            var items = await HttpHelper.FetchTvShowsDataAsync(url, 10);

            var allFilms = items.Take(10).ToList();

            return allFilms;
        }
    }
}
