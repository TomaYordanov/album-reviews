using Microsoft.AspNetCore.Mvc;
using AlbumReviews.Data;
using AlbumReviews.ViewModels;
using AlbumReviews.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;

namespace AlbumReviews.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AlbumReviewsContext _context;
        private readonly ReviewService _reviewService;

        public ReviewController(AlbumReviewsContext context, ReviewService reviewService)
        {
            _context = context;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index(int albumId)
        {
            var album = await _context.Albums.Where(a => a.AlbumId == albumId).Select(a => new AlbumReviewViewModel{
                AlbumId = a.AlbumId,
                Title = a.Title,
                Cover = a.Cover,
                Reviews = a.Reviews.Select(r => new ReviewViewModel
                {
                ReviewId = r.ReviewId,
                Rating = r.Rating,
                ReviewContent = r.ReviewText,
                UserName = r.User.UserName })
                .ToList()})
                .FirstOrDefaultAsync();



            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview (int albumId, int rating, string reviewContent)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

            await _reviewService.AddReviewAsync(albumId, userId, rating, reviewContent);
            return RedirectToAction(nameof(Index), new { albumId = albumId });
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReview(int reviewId, int albumId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

            if (await _reviewService.DeleteReviewAsync(reviewId, userId))
            {
                return RedirectToAction(nameof(Index), new { albumId = albumId });
            }

            return Forbid();
        }
    }
}
