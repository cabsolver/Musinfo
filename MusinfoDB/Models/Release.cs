using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class Release
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }

        [Required]
        public string Type { get; set; }


        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Artist> Artists { get; set; } = new HashSet<Artist>();
    }
}
