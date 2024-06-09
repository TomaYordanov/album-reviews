using AlbumReviews.Data;
using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AlbumReviews.Services
{
    public class ReviewService
    {
        private AlbumReviewsContext _context;
        
        public ReviewService(AlbumReviewsContext context)
        {
            _context = context;
        }
        public async Task AddReviewAsync(int albumId, string userId, int rating, string reviewContent)
        {
            var review = new Review
            {
                AlbumId = albumId,
                UserId = userId,
                Rating = rating,
                ReviewText = reviewContent

            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteReviewAsync(int reviewId, string userId)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId && x.UserId == userId);
            if(review == null)
            {
                return false;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
