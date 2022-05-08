using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
