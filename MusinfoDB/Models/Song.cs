using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusinfoDB.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }

        public int ReleaseId { get; set; }
        public Release Release { get; set; } 

        [Required]
        public int AudioSourceId { get; set; }
        public AudioSource AudioSource { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public ICollection<VideoClip> VideoClips { get; set; } = new HashSet<VideoClip>();
    }
}
