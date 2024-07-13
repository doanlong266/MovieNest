using MovieNest.Helpers;
using MovieNest.Model;
using Newtonsoft.Json;

namespace MovieNest.View.Film
{
    public partial class FilmDetailScreen : ContentPage
    {
        public readonly string url = "https://phimapi.com/phim/";

        public FilmDetailScreen(string id)
        {
            InitializeComponent();
            LoadInfoFilm(id);
        }

        public async void LoadInfoFilm(string id)
        {
            string jsonResponse = await HttpHelper.GetResponseAsync(url + id);
            if (!string.IsNullOrEmpty(jsonResponse))
            {
                FilmDetailModel filmDetail = JsonConvert.DeserializeObject<FilmDetailModel>(jsonResponse);
                if (filmDetail != null && filmDetail.Episodes != null && filmDetail.Episodes.Count > 0)
                {
                 
                    Episode episode1 = filmDetail.Episodes[0];
                    if (episode1 != null && episode1.ServerData != null && episode1.ServerData.Count > 0)
                    {
                        ServerData serverData = episode1.ServerData[0];
                        if (serverData != null)
                        {
                            Media.Source = serverData.LinkM3u8;
                        }
                    }
                }
            }
            else
            {
             
            }
        }
    }
}
