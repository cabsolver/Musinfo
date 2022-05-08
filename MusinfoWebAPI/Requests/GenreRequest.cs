using MusinfoDB.Models;

namespace MusinfoWebAPI.Requests
{
    public class GenreRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Genre GetGenreEntity(GenreRequest request)
        {
            return new Genre
            { 
                Name = request.Name
            };
        }
    }
}
