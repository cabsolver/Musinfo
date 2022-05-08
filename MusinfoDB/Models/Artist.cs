using System.ComponentModel.DataAnnotations;

namespace MusinfoDB.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }

        public ICollection<Release> Releases { get; set; } = new HashSet<Release>();
    }
}
