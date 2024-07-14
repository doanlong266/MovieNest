using MovieNest.Helpers;
using MovieNest.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNest.ViewModel
{
    public class PhimLeViewModel
    {
        public readonly string url = "https://phimapi.com/v1/api/danh-sach/phim-le?page=";

        public async Task<List<Item>> FetchPhimLeDataAsync()
        {
            var items = await HttpHelper.FetchPhimLeDataAsync(url, 10);

            var allFilms = items.Take(20).ToList();

            return allFilms;
        }
    }
}
