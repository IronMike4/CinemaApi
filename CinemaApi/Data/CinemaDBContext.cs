using CinemaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data
{
  public class CinemaDBContext : DbContext
  {
    public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
  }
}
