using DevExpress.Maui.Editors;
using MovieNest.Helpers;
using MovieNest.View.Film;
using MovieNest.View.Search;
using MovieNest.ViewModel;

namespace MovieNest.View.Home
{
    public partial class HomeScreen : ContentPage
    {
        public HomeScreen()
        {
            InitializeComponent();
            LoadingHepler.Run();    
            BindingContext = new HomeViewModel();
            LoadingHepler.Stop();
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
                        image.IsEnabled = true;
                    }
                }
            }
        }
        private async void Search(object sender, EventArgs e)
        {
            
            if (sender is TextEdit edit)
            {
                edit.IsEnabled = false;
                if (edit.GestureRecognizers[0] is TapGestureRecognizer tapGestureRecognizer)
                {
                    await Navigation.PushAsync(new SearchScreen());
                    edit.IsEnabled = true;
                }
            }
        }
    }
}
