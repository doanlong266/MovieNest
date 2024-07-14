using MovieNest.Helpers;
using MovieNest.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MovieNest.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TrendingFilmModel> TrendingFilms { get; set; }
        public ObservableCollection<TrendingFilmModel> PhimBoFilms { get; set; }
        public ObservableCollection<TrendingFilmModel> PhimLeFilms { get; set; }
        public ObservableCollection<TrendingFilmModel> PhimHoatHinhFilms { get; set; }
        public ObservableCollection<TrendingFilmModel> TvShowsFilms { get; set; }



        public HomeViewModel()
        {
            TrendingFilms = new ObservableCollection<TrendingFilmModel>
            {
                new TrendingFilmModel { IMAGE = "https://img.phimapi.com/upload/vod/20240627-1/74f096acaf7d38e592fa4a535f6bbadd.jpg" , FILMNAME = "Độ Hoa Niên",PARAMETER="do-hoa-nien"},
            };

            PhimBoFilms = new ObservableCollection<TrendingFilmModel>();
            _ = FetchAndPopulatePhimBoFilmsAsync();
            PhimLeFilms = new ObservableCollection<TrendingFilmModel>();
            _ = FetchAndPopulatePhimLeFilmsAsync();
            PhimHoatHinhFilms = new ObservableCollection<TrendingFilmModel>();
            _ = FetchAndPopulatePhimHoatHinhFilmsAsync();
            TvShowsFilms = new ObservableCollection<TrendingFilmModel>();
            _ = FetchAndPopulateTvShowsFilmsAsync();

        }

        private async Task FetchAndPopulatePhimBoFilmsAsync()
        {
            var phimBoViewModel = new PhimBoViewModel();
            var items = await phimBoViewModel.FetchPhimBoDataAsync();

            foreach (var item in items)
            {
                PhimBoFilms.Add(new TrendingFilmModel
                {
                    IMAGE = $"https://img.phimapi.com/{item.PosterUrl}",
                    FILMNAME = item.Name,
                    PARAMETER = item.Slug
                });
            }
        }

        private async Task FetchAndPopulatePhimLeFilmsAsync()
        {
            var phimLeViewModel = new PhimLeViewModel();
            var items = await phimLeViewModel.FetchPhimLeDataAsync();

            foreach (var item in items)
            {
                PhimLeFilms.Add(new TrendingFilmModel
                {
                    IMAGE = $"https://img.phimapi.com/{item.PosterUrl}",
                    FILMNAME = item.Name,
                    PARAMETER = item.Slug
                });
            }
        }
        private async Task FetchAndPopulatePhimHoatHinhFilmsAsync()
        {
            var phimHoatHinhViewModel = new PhimHoatHinhViewModel();
            var items = await phimHoatHinhViewModel.FetchPhimHoatHinhDataAsync();

            foreach (var item in items)
            {
                PhimHoatHinhFilms.Add(new TrendingFilmModel
                {
                    IMAGE = $"https://img.phimapi.com/{item.PosterUrl}",
                    FILMNAME = item.Name,
                    PARAMETER = item.Slug
                });
            }
        }
        private async Task FetchAndPopulateTvShowsFilmsAsync()
        {
            var tvShowsViewModel = new TVShowsViewModel();
            var items = await tvShowsViewModel.FetchTvShowsDataAsync();

            foreach (var item in items)
            {
                TvShowsFilms.Add(new TrendingFilmModel
                {
                    IMAGE = $"https://img.phimapi.com/{item.PosterUrl}",
                    FILMNAME = item.Name,
                    PARAMETER = item.Slug
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
