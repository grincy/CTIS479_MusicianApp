using DataAccess.Entities;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Music> Music { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
