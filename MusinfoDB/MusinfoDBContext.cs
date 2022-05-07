using Microsoft.EntityFrameworkCore;
using MusinfoDB.Models;

namespace MusinfoDB
{
    public class MusinfoDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public MusinfoDBContext(DbContextOptions<MusinfoDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
