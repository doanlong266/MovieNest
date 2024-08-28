using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MovieNest.Helpers;
using MovieNest.View.Film;
using MovieNest.View.Search;
using MovieNest.ViewModel;
using System.Collections;

namespace MovieNest.View.Home
{
    public partial class HomeScreen : ContentPage
    {
        private CancellationTokenSource _cancellationTokenSource;
        private int _currentIndex = 0;

        public HomeScreen()
        {
            InitializeComponent();
            InitAsync();
        }
        private async void InitAsync()
        {
            LoadingHepler.Run();
            var viewModel = new HomeViewModel();
            BindingContext = viewModel;
            StartAutoScroll();
            await viewModel.LoadDataAsync();
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
        private void StartAutoScroll()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (indicatorView.ItemsSource == null)
                    return false; // Stop if there are no items

                _currentIndex++;

                if (_currentIndex >= ((ICollection)indicatorView.ItemsSource).Count)
                {
                    _currentIndex = 0; // Loop back to the first item
                }

                indicatorView.Position = _currentIndex;

                // Check if we need to stop the timer
                return !cancellationToken.IsCancellationRequested;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _cancellationTokenSource?.Cancel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                StartAutoScroll(); // Restart the timer when the page becomes visible again
            }
        }
    }
}
