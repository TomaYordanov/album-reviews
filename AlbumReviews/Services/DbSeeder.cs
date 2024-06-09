using AlbumReviews.Data;
using AlbumReviews.Models;
using Microsoft.AspNetCore.Identity;

namespace AlbumReviews.Services
{
    public class DbSeeder
    {
        private readonly AlbumReviewsContext _context;

        public DbSeeder(AlbumReviewsContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Roles.Any())
            {

                _context.Roles.AddRange(
                  new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                  new IdentityRole { Name = "Martin", NormalizedName = "MARTIN" }
                  );
            }

            if (!_context.Users.Any())
            {

                _context.Users.AddRange(
                    new User { UserName = "user1", Email = "user1@example.com" },
                    new User { UserName = "user2", Email = "user2@example.com" }
                );
            }


            if (!_context.Albums.Any())
            {
                _context.Albums.AddRange(
                   new Album { Title = "Georgi 2014", Artist = "Georgi", ReleaseYear = 2014, Genre = "Femboy pop", Cover = "https://www.eatingwell.com/thmb/GUIE6Jl4whX0OODcsrb7-nPA4PI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/afh-chris-bradshaw-2ed12baa72e14b2a8982757cf77191fb.jpg" },
                   new Album { Title = "I mazhete sashto plachat", Artist = "Azis", ReleaseYear = 2000, Genre = "Chalga", Cover = "https://i.scdn.co/image/ab67616d0000b2730c05c480f7a51f13e7d1b930" }

                );
            }
            _context.SaveChanges();
        }
    }
}
