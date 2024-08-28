using MovieNest.Helpers;
using MovieNest.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MovieNest.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieItem> TrendingFilms { get; set; }
        public ObservableCollection<MovieItem> PhimBoFilms { get; set; }
        public ObservableCollection<MovieItem> PhimLeFilms { get; set; }
        public ObservableCollection<MovieItem> PhimHoatHinhFilms { get; set; }
        public ObservableCollection<MovieItem> TvShowsFilms { get; set; }



        public HomeViewModel()
        {
            TrendingFilms = new ObservableCollection<MovieItem>();
            PhimBoFilms = new ObservableCollection<MovieItem>();
            PhimLeFilms = new ObservableCollection<MovieItem>();
            PhimHoatHinhFilms = new ObservableCollection<MovieItem>();
            TvShowsFilms = new ObservableCollection<MovieItem>();
        }

        public async Task LoadDataAsync()
        {
            var trendingTask = FetchAndPopulateTrendingFilmsAsync();
            var phimBoTask = FetchAndPopulatePhimBoFilmsAsync();
            var phimLeTask = FetchAndPopulatePhimLeFilmsAsync();
            var phimHoatHinhTask = FetchAndPopulatePhimHoatHinhFilmsAsync();
            var tvShowsTask = FetchAndPopulateTvShowsFilmsAsync();

            await Task.WhenAll(trendingTask, phimBoTask, phimLeTask, phimHoatHinhTask, tvShowsTask);
        }

        private async Task FetchAndPopulateTrendingFilmsAsync()
        {
            var trendingViewModel = new TrendingFilmViewModel();
            var items = await trendingViewModel.FetchTrendingFilmDataAsync();

            foreach (var item in items)
            {
                TrendingFilms.Add(new MovieItem
                {
                    IMAGE = item.PosterUrl,
                    FILMNAME = item.Name,
                    PARAMETER = item.Slug
                });
            }
        }

        private async Task FetchAndPopulatePhimBoFilmsAsync()
        {
            var phimBoViewModel = new PhimBoViewModel();
            var items = await phimBoViewModel.FetchPhimBoDataAsync();

            foreach (var item in items)
            {
                PhimBoFilms.Add(new MovieItem
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
                PhimLeFilms.Add(new MovieItem
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
                PhimHoatHinhFilms.Add(new MovieItem
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
                TvShowsFilms.Add(new MovieItem
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
