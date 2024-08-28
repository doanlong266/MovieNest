using MovieNest.Helpers;
using MovieNest.Model;

namespace MovieNest.ViewModel
{
    public class TrendingFilmViewModel
    {
        public readonly string url = "https://phimapi.com/danh-sach/phim-moi-cap-nhat?page=";

        public async Task<List<TrendingFilmModel>> FetchTrendingFilmDataAsync()
        {
            var items = await HttpHelper.FetchTrendingFilmAsync(url, 10);
            var films2024 = items.Where(film => film.Year == 2024)
                                 .Take(5)
                                 .ToList();

            return films2024;
        }
    }
}
