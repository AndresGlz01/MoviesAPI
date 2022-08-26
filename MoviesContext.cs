using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI;

public class MoviesContext : DbContext
{
    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Genre>? Genres { get; set; }
    public DbSet<Actor>? Actors { get; set; }

    public MoviesContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}