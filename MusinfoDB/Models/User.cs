using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();
        public ICollection<Playlist> Playlists { get; set; } = new HashSet<Playlist>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
