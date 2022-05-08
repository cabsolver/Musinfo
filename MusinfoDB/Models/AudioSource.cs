using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class AudioSource
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public string Title { get; set; }

        [Required]
        public byte[] Data { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
