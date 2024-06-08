using Microsoft.AspNetCore.Mvc;
using AlbumReviews.Data;
using AlbumReviews.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AlbumReviewsContext _context;

        public ReviewController(AlbumReviewsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int albumId)
        {
            var album = await _context.Albums.Where(a => a.AlbumId == albumId).Select(a => new AlbumReviewViewModel{
                AlbumId = a.AlbumId,
                Title = a.Title,
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
    }
}
