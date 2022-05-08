using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusinfoDB.Models
{
    public class VideoClip
    {
        public int Id { get; set; }

        [Column(TypeName="time")]
        public TimeSpan Duration { get; set; }

        public DateTime PublicationDate { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int SongId { get; set; }
        public Song Song { get; set; }

        public ICollection<VideoClip> VideoClips { get; set; }
    }
}
