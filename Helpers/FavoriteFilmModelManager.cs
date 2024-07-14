using MovieNest.Model;
using System.Xml.Serialization;

namespace MovieNest.Helpers
{
    public class FavoriteFilmModelManager
    {
        public static FavoriteFilmModel LoadFavoriteFromXml(string filePath)
        {
            FavoriteFilmModel favorite = null;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FavoriteFilmModel));
                    favorite = (FavoriteFilmModel)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading favorite from XML: {ex.Message}");
            }

            return favorite;
        }

        public static void SaveFavoriteToXml(string filePath, FavoriteFilmModel favorite)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FavoriteFilmModel));
                serializer.Serialize(writer, favorite);
            }
        }

        public static void RemoveFavoriteById(string filePath, string movieId)
        {
            FavoriteFilmModel favorite = LoadFavoriteFromXml(filePath);

            if (favorite != null)
            {
                var filmToRemove = favorite.FavoriteFilms.FirstOrDefault(f => f.ID == movieId);
                if (filmToRemove != null)
                {
                    favorite.FavoriteFilms.Remove(filmToRemove);

                    SaveFavoriteToXml(filePath, favorite);
                }
                else
                {
                    Console.WriteLine("Movie ID not found in favorites.");
                }
            }
        }
        
    }
}
