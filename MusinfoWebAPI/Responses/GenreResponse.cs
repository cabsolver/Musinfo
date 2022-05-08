using MusinfoDB.Models;

namespace MusinfoWebAPI.Responses
{
    public class GenreResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static GenreResponse GetGenreResponse(Genre genre)
        {
            return new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
