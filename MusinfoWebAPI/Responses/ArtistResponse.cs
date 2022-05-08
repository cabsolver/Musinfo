using MusinfoDB.Models;

namespace MusinfoWebAPI.Responses
{
    public class ArtistResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public static ArtistResponse GetArtistResponse(Artist artist)
        {
            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Biography = artist.Biography
            };
        }
    }
}
