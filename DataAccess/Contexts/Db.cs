using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Music> Music { get; set; }

        public DbSet<Album> Albums { get; set; }


        public DbSet<AlbumsMusic> AlbumsMusics { get; set; }


        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
