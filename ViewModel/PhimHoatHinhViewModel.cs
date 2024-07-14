using MovieNest.Helpers;

namespace MovieNest.ViewModel
{
    public class PhimHoatHinhViewModel
    {
        public readonly string url = "https://phimapi.com/v1/api/danh-sach/hoat-hinh?page=";

        public async Task<List<ItemHH>> FetchPhimHoatHinhDataAsync()
        {
            var items = await HttpHelper.FetchPhimHoatHinhDataAsync(url, 10);

            var allFilms = items.Take(10).ToList();

            return allFilms;
        }
    }
}
