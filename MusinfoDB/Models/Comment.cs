using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public int VideoClipId { get; set; }
        public VideoClip VideoClip { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
