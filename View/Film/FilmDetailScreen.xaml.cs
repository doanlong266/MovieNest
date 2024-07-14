using MovieNest.Helpers;
using MovieNest.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieNest.View.Film
{
    public partial class FilmDetailScreen : ContentPage
    {
        public readonly string url = "https://phimapi.com/phim/";
        private List<ServerData> allServerData;
        private FilmDetailModel currentFilmDetail;

        public FilmDetailScreen(string id)
        {
            InitializeComponent();
            BindingContext = this;
            LoadingHepler.Run();
            LoadInfoFilm(id);
            LoadingHepler.Stop();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Media != null)
            {
                Media.Stop();
            }
        }

        public async void LoadInfoFilm(string id)
        {
            string jsonResponse = await HttpHelper.GetResponseAsync(url + id);
            if (!string.IsNullOrEmpty(jsonResponse))
            {
                var jsonObjects = jsonResponse.Split(new[] { "}{" }, StringSplitOptions.None);

                foreach (var jsonObject in jsonObjects)
                {
                    string validJson = jsonObject;
                    if (!jsonObject.StartsWith("{"))
                    {
                        validJson = "{" + jsonObject;
                    }
                    if (!jsonObject.EndsWith("}"))
                    {
                        validJson = jsonObject + "}";
                    }

                    try
                    {
                        var jObject = JObject.Parse(validJson);

                        if (jObject.ContainsKey("status") && jObject.ContainsKey("msg"))
                        {
                            var baseResponse = jObject.ToObject<BaseResponse>();
                            if (baseResponse != null && baseResponse.Status)
                            {
                                var filmDetail = jObject.ToObject<FilmDetailModel>();
                                if (filmDetail != null && filmDetail.Episodes != null && filmDetail.Episodes.Count > 0)
                                {
                                    currentFilmDetail = filmDetail;

                                    string episodeCurrent = currentFilmDetail.Movie.EpisodeCurrent;
                                    string episodeInfo;

                                    var match = System.Text.RegularExpressions.Regex.Match(episodeCurrent, @"\((\d+/\d+)\)");
                                    if (match.Success)
                                    {
                                        episodeInfo = match.Groups[1].Value;
                                    }
                                    else
                                    {
                                        episodeInfo = $"{episodeCurrent.Replace("Tập", "").Trim()}/{currentFilmDetail.Movie.EpisodeTotal}";
                                    }

                                    string country = currentFilmDetail.Movie.Country[0].Name;
                                    string quality = currentFilmDetail.Movie.Quality;
                                    string lang = currentFilmDetail.Movie.Lang;
                                    string categories = string.Join(", ", currentFilmDetail.Movie.Category.Select(c => c.Name));
                                    string detail = $"{currentFilmDetail.Movie.Year} | {episodeInfo} tập | {country}";
                                    string descrip = $"Nội dung {categories.ToLower()}";
                                    string qualitylang = $"{quality} | {lang}";
                                    Detail.Text = detail;
                                    Descrip.Text = descrip;
                                    qualityLang.Text = qualitylang;
                                    allServerData = currentFilmDetail.Episodes
                                        .SelectMany(episode => episode.ServerData)
                                        .Select(serverData => new ServerData
                                        {
                                            Name = serverData.Name.Replace("Tập", ""),
                                            LinkM3u8 = serverData.LinkM3u8,
                                            SelectEpisode = false,
                                            SelectBackground = "#3898ec",
                                            LinkEmbed = serverData.LinkEmbed
                                        })
                                        .ToList();

                                    if (allServerData.Any())
                                    {
                                        var firstServerData = allServerData.First();
                                        firstServerData.SelectEpisode = true;
                                        firstServerData.SelectBackground = "#f1b722";
                                        Media.Source = firstServerData.LinkM3u8;
                                        nameEpisode.Text = currentFilmDetail.Movie.Name+" - " + "Tập " + firstServerData.Name;
                                    }

                                    lsvEpisode.ItemsSource = allServerData;
                                    CheckAndSetFavoriteColor();
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"Non-success status: {baseResponse.Msg}");
                            }
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"JSON Parsing Error: {ex.Message}");
                    }
                }
            }
            else
            {
            }
        }




        private void Back(object sender, EventArgs e)
        {
            if (Media != null)
            {
                Media.Stop();
            }

            Navigation.PopAsync();
        }

        private void chooseEpisode(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is ServerData selectedServerData)
            {
                foreach (var serverData in allServerData)
                {
                    serverData.SelectEpisode = false;
                    serverData.SelectBackground = "#3898ec";
                    serverData.Name.Replace("Tập", "");
                }

                selectedServerData.SelectEpisode = true;
                selectedServerData.Name.Replace("Tập", "");
                selectedServerData.SelectBackground = "#f1b722";

                Media.Source = selectedServerData.LinkM3u8;
                nameEpisode.Text = currentFilmDetail.Movie.Name+" - " + "Tập" + selectedServerData.Name;

                lsvEpisode.ItemsSource = null;
                lsvEpisode.ItemsSource = allServerData;
            }
        }

        private void addFavorite(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.xml");
            FavoriteFilmModel favoriteModel = FavoriteFilmModelManager.LoadFavoriteFromXml(filePath) ?? new FavoriteFilmModel();

            if (favoriteModel.FavoriteFilms.Any(f => f.ID == currentFilmDetail.Movie.Slug))
            {
                love.TextColor = Color.FromHex("#fff");
                FavoriteFilmModelManager.RemoveFavoriteById(filePath, currentFilmDetail.Movie.Slug);
                return;
            }

            favoriteModel.FavoriteFilms.Add(new FavoriteFilm
            {
                ID = currentFilmDetail.Movie.Slug,
                NAME = currentFilmDetail.Movie.Name,
                PostUrl = currentFilmDetail.Movie.PosterUrl
            });

            FavoriteFilmModelManager.SaveFavoriteToXml(filePath, favoriteModel);
            love.TextColor = Color.FromHex("#a21d0a");
        }

        private async void downloadFilm(object sender, EventArgs e)
        {
            var currentEpisode = allServerData.FirstOrDefault(sd => sd.SelectEpisode);
            if (currentEpisode != null)
            {
                string downloadUrl = currentEpisode.LinkM3u8;

#if __ANDROID__
        // Lấy thư mục tải xuống của thiết bị Android
        string downloadsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;

        // Chuyển đổi tên phim và tên tập phim sang không dấu
        string sanitizedMovieName = RemoveDiacritics.RemoveVietnameseDiacritics(currentFilmDetail.Movie.Name);
        string sanitizedEpisodeName = RemoveDiacritics.RemoveVietnameseDiacritics(currentEpisode.Name);

        // Đảm bảo tên tệp không chứa ký tự không hợp lệ
        sanitizedMovieName = string.Join("_", sanitizedMovieName.Split(Path.GetInvalidFileNameChars()));
        sanitizedEpisodeName = string.Join("_", sanitizedEpisodeName.Split(Path.GetInvalidFileNameChars()));

        string filePath = Path.Combine(downloadsPath, $"{sanitizedMovieName}{sanitizedEpisodeName}.mp4");
#else
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{currentFilmDetail.Movie.Name}_{currentEpisode.Name}.mp4");
#endif

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var m3u8Response = await client.GetStringAsync(downloadUrl);

                        var segmentUrls = m3u8Response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Where(line => !line.StartsWith("#"))
                                                      .Select(line => new Uri(new Uri(downloadUrl), line).ToString())
                                                      .ToList();

                        var tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                        Directory.CreateDirectory(tempFolder);

                        var segmentFiles = new List<string>();

                        foreach (var segmentUrl in segmentUrls)
                        {
                            var segmentFileName = Path.Combine(tempFolder, Path.GetFileName(segmentUrl));
                            segmentFiles.Add(segmentFileName);

                            var segmentResponse = await client.GetAsync(segmentUrl);
                            segmentResponse.EnsureSuccessStatusCode();

                            using (var segmentFileStream = new FileStream(segmentFileName, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                await segmentResponse.Content.CopyToAsync(segmentFileStream);
                            }
                        }

                        using (var outputFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            foreach (var segmentFile in segmentFiles)
                            {
                                using (var segmentFileStream = new FileStream(segmentFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    await segmentFileStream.CopyToAsync(outputFileStream);
                                }
                            }
                        }

                        Directory.Delete(tempFolder, true);

                        await DisplayAlert("Thông báo", "Đã tải xuống phim thành công.", "OK");
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Lỗi", $"Không thể tải xuống phim: {ex.Message}", "OK");
                    }
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Vui lòng chọn một tập để tải xuống.", "OK");
            }
        }




        private void CheckAndSetFavoriteColor()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favorites.xml");
            FavoriteFilmModel favoriteModel = FavoriteFilmModelManager.LoadFavoriteFromXml(filePath);

            if (favoriteModel != null && favoriteModel.FavoriteFilms.Any(f => f.ID == currentFilmDetail.Movie.Slug))
            {
                love.TextColor = Color.FromHex("#a21d0a");
            }
            else
            {
                love.TextColor = Color.FromHex("#fff");
            }
        }
    }
}
