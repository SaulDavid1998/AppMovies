using Microsoft.EntityFrameworkCore;

namespace AppMovies.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext() { }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }


        public DbSet<Pelicula> Pelicula { get; set; } = null!;
        public DbSet<Director> Director { get; set; } = null!;

        public DbSet<Estudio> Estudios { get; set;} = null!;

    }
}
