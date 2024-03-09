using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieRentals>().HasKey(mr => new { mr.UserId, mr.MovieId });

            modelBuilder.Entity<MovieRentals>()
                .HasOne<UserModel>(mr => mr.User)
                .WithMany(u => u.MovieRentals)
                .HasForeignKey(mr => mr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieRentals>()
                .HasOne<MovieModel>(mr => mr.Movie)
                .WithMany(m => m.MovieRentals)
                .HasForeignKey(mr => mr.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieModel>()
                .Property(m => m.CostPerDay)
                .HasColumnType("decimal")
                .HasPrecision(20,3);

            modelBuilder.Entity<UserModel>()
                .Property(u => u.Balance)
                .HasColumnType("deciamal")
                .HasPrecision(20, 2);
        }

        DbSet<UserModel> Users { get; set; }
        DbSet<MovieModel> Movies { get; set; }
        DbSet<MovieRentals> MovieRentals { get; set; }
    }
}
