using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AlbumReviews.Data
{
    public class AlbumReviewsContext : IdentityDbContext<User>
    {
        public AlbumReviewsContext(DbContextOptions<AlbumReviewsContext> options)
            : base(options)
        {

        }
        public override DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Album)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Review)
                .WithMany(r => r.Replies)
                .HasForeignKey(r => r.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reply>()
                .HasOne(r => r.User)
                 .WithMany(u => u.Replies)
                 .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Track>()
                .HasOne(t => t.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicReviewDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }



    }
}
