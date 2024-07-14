using DevExpress.Maui.Editors;

namespace MovieNest.View.Search;

public partial class SearchScreen : ContentPage
{
	public SearchScreen()
	{
		InitializeComponent();
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
}