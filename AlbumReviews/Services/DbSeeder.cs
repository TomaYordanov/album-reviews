using System.Linq;
using AlbumReviews.Models;
using AlbumReviews.Data;


namespace AlbumReviews.Services
{
    public class DbSeeder
    {
        private AlbumReviewsContext _dbContext;
        public DbSeeder(AlbumReviewsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext == null)
            {
                return;
            }
            var album1 = new Album { Title = "Georgi 2014", Artist = "Georgi", ReleaseYear = 2014, Genre = "Femboy pop", Cover = "https://www.eatingwell.com/thmb/GUIE6Jl4whX0OODcsrb7-nPA4PI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/afh-chris-bradshaw-2ed12baa72e14b2a8982757cf77191fb.jpg" };
            var album2 = new Album { Title = "I mazhete sashto plachat", Artist = "Azis", ReleaseYear = 2000, Genre = "Chalga", Cover = "https://i.scdn.co/image/ab67616d0000b2730c05c480f7a51f13e7d1b930" };

            _dbContext.Albums.AddRange(album1, album2);
            _dbContext.SaveChanges();

        }
    }
}
