using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MusinfoDB
{
    public class MusinfoDBContextFactory : IDesignTimeDbContextFactory<MusinfoDBContext>
    {
        public MusinfoDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusinfoDBContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=LONE-LAPTOP\\LITHEFEXPRESS;Initial Catalog=MusinfoDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            );
            return new MusinfoDBContext(optionsBuilder.Options);
        }
    }
}
