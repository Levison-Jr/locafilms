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
                .HasPrecision(18, 2);

            modelBuilder.Entity<UserModel>()
                .Property(u => u.Balance)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<MovieRentals> MovieRentals { get; set; }
    }
}
