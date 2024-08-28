using MovieNest.Helpers;
using MovieNest.Model;

namespace MovieNest.ViewModel
{
    public class PhimBoViewModel
    {
        public readonly string url = "https://phimapi.com/v1/api/danh-sach/phim-bo?page=";

        public async Task<List<ItemModel>> FetchPhimBoDataAsync()
        {
            var items = await HttpHelper.FetchPhimBoDataAsync(url, 10);

            var chineseFilms = items.Where(item => item.Country.Any(c => c.Name == "Trung Quốc")).Take(5).ToList();
            var koreanFilms = items.Where(item => item.Country.Any(c => c.Name == "Hàn Quốc")).Take(5).ToList();

            var remainingItems = items.Except(chineseFilms).Except(koreanFilms).Take(10).ToList();

            var orderedFilms = new List<ItemModel>();
            orderedFilms.AddRange(chineseFilms);
            orderedFilms.AddRange(koreanFilms);
            orderedFilms.AddRange(remainingItems);
            return orderedFilms;
        }
    }
}
