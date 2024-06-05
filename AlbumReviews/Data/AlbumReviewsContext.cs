using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.Data
{
    public class AlbumReviewsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Album)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AlbumId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reply>()
                .HasOne(r => r.Review)
                .WithMany(r => r.Replies)
                .HasForeignKey(r => r.ReviewId);

            modelBuilder.Entity<Reply>()
                .HasOne(r => r.User)
                .WithMany(u => u.Replies)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.AlbumId);
        }



    }
}
