using MovieNest.View.Film;
using MovieNest.ViewModel;

namespace MovieNest.View.Home
{
    public partial class HomeScreen : ContentPage
    {
        public HomeScreen()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
        private async void Detail(object sender,EventArgs e)
        {
            if (sender is Image image)
            {
                image.IsEnabled = false;
                if (image.GestureRecognizers[0] is TapGestureRecognizer tapGestureRecognizer)
                {
                    if (tapGestureRecognizer.CommandParameter is string id)
                    {
                        await Navigation.PushAsync(new FilmDetailScreen(id));
                    }
                }
            }
        }
    }
}
