using Microsoft.EntityFrameworkCore;
using MusinfoDB.Models;

namespace MusinfoDB
{
    public class MusinfoDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<AudioSource> AudioSources { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<VideoClip> VideoClips { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public MusinfoDBContext(DbContextOptions<MusinfoDBContext> options) : base(options)
        { }

    }
}
