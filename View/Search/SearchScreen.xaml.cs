using MovieNest.Helpers;
using MovieNest.Model;
using MovieNest.View.Film;

namespace MovieNest.View.Search;

public partial class SearchScreen : ContentPage
{
    public string BaseUrl = "https://phimapi.com/v1/api/tim-kiem";
    const int ItemHeight = 250;
    const int ItemSpacing = 10;
    const int ItemsPerRow = 2;

    public SearchScreen()
    {
        InitializeComponent();
        SearchFilm.Focus();
    }

    private void Back(object sender, EventArgs e)
    {
        if (sender is Label label)
        {
            label.IsEnabled = false;
            if (label.GestureRecognizers[0] is TapGestureRecognizer tapGestureRecognizer)
            {
                Navigation.PopAsync();
                label.IsEnabled = true;
            }
        }
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

    private async void Search(object sender, FocusEventArgs e)
    {
        string query = SearchFilm.Text;

        if (!string.IsNullOrWhiteSpace(query))
        {
            LoadingHepler.Run();
            List<FilmModel> results = await HttpHelper.SearchAsync(BaseUrl, query, 10);
            if (results.Count > 0)
            {
                FilmSearch.ItemsSource = results;

                if (results.Count == 1|| results.Count == 2)
                {
                    FilmSearch.HeightRequest = 500;
                }
                else
                {
                    int numberOfRows = (int)Math.Ceiling((double)results.Count / ItemsPerRow);

                    int totalHeight = (ItemHeight * numberOfRows) + (ItemSpacing * (numberOfRows - 1));

                    FilmSearch.HeightRequest = totalHeight > ItemHeight ? totalHeight : ItemHeight + 10; 
                }

                LoadingHepler.Stop();
                EmptySearch.IsVisible = false;
            }
            else
            {
                FilmSearch.ItemsSource = null;
                FilmSearch.HeightRequest = 0;
                LoadingHepler.Stop();
                EmptySearch.IsVisible = true;
            }
        }
        else
        {
            FilmSearch.ItemsSource = null;
            FilmSearch.HeightRequest = 0;
            LoadingHepler.Stop();
            EmptySearch.IsVisible = true;
        }
    }


}
