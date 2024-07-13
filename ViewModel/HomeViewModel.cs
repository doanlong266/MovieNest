using MovieNest.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MovieNest.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TrendingFilmModel> TrendingFilms { get; set; }

        public HomeViewModel()
        {
            TrendingFilms = new ObservableCollection<TrendingFilmModel>
            {
                new TrendingFilmModel { IMAGE = "https://img.phimapi.com/upload/vod/20240627-1/74f096acaf7d38e592fa4a535f6bbadd.jpg" , FILMNAME = "Độ Hoa Niên",PARAMETER="do-hoa-nien"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
