using MusinfoDB.Models;
using System.ComponentModel.DataAnnotations;

namespace MusinfoWebAPI.Requests
{
    public class ArtistRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is empty")]
        public string Name { get; set; }
        public string Biography { get; set; }

        public static Artist GetArtistEntity(ArtistRequest request)
        {
            return new Artist
            {
                Name = request.Name,
                Biography = request.Biography
            };
        }
    }
}
