using MovieNest.Helpers;
using MovieNest.Model;
using MovieNest.View.Film;

namespace MovieNest.View.Favorite
{
    public partial class FavoriteScreen : ContentPage
    {
        const int ItemHeight = 250;
        const int ItemSpacing = 10;
        const int ItemsPerRow = 2;

        public FavoriteScreen()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadFavorite();
        }

        private async void Detail(object sender, EventArgs e)
        {
            if (sender is Image image)
            {
                image.IsEnabled = false;
                if (image.GestureRecognizers[0] is TapGestureRecognizer tapGestureRecognizer)
                {
                    if (tapGestureRecognizer.CommandParameter is string id)
                    {
                        await Navigation.PushAsync(new FilmDetailScreen(id));
                        image.IsEnabled = true;
                    }
                }
            }
        }

        private void LoadFavorite()
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.xml");

                FavoriteFilmModel favoriteFilms = FavoriteFilmModelManager.LoadFavoriteFromXml(filePath);

                if (favoriteFilms != null && favoriteFilms.FavoriteFilms.Any())
                {
                    FilmFavorite.ItemsSource = favoriteFilms.FavoriteFilms;

                    if (favoriteFilms.FavoriteFilms.Count == 1 || favoriteFilms.FavoriteFilms.Count == 2)
                    {
                        FilmFavorite.HeightRequest = 500;
                    }
                    else
                    {
                        int numberOfRows = (int)Math.Ceiling((double)favoriteFilms.FavoriteFilms.Count / ItemsPerRow);

                        int totalHeight = (ItemHeight * numberOfRows) + (ItemSpacing * (numberOfRows - 1));

                        FilmFavorite.HeightRequest = totalHeight > ItemHeight ? totalHeight : ItemHeight + 10; 
                    }

                    EmptyFavorite.IsVisible = false;
                }
                else
                {
                    FilmFavorite.ItemsSource = null;
                    FilmFavorite.HeightRequest = 0;
                    EmptyFavorite.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading favorite films: {ex.Message}");
            }
        }
    }
}
