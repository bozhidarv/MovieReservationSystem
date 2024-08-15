using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Data;

public class MovieTicketContext(DbContextOptions<MovieTicketContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieProjection> MovieProjections { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().ToTable("Movie");
        modelBuilder.Entity<MovieProjection>().ToTable("MovieProjection");
        modelBuilder.Entity<Theater>().ToTable("Theater");
        modelBuilder.Entity<Genre>().ToTable("Genre");
    }

}