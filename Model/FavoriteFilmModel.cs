namespace MovieNest.Model
{
    public class FavoriteFilmModel
    {
        public List<FavoriteFilm> FavoriteFilms { get; set; }

        public FavoriteFilmModel()
        {
            FavoriteFilms = new List<FavoriteFilm>();
        }
    }

    public class FavoriteFilm
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }
        public string? PostUrl { get; set; }
    }
}
