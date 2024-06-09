using AlbumReviews.Data;
using AlbumReviews.Models;
using AlbumReviews.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumReviews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlbumReviewsContext _context;

        public HomeController(ILogger<HomeController> logger, AlbumReviewsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _context.Albums
                .Include(a => a.Reviews)
                .OrderByDescending(a => a.ReleaseYear)
                .Select(a => new AlbumViewModel
                {
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    Artist = a.Artist,
                    Genre = a.Genre,
                    ReleaseDate = a.ReleaseYear,
                    Cover = a.Cover,
                    ReviewCount = a.Reviews.Count,
                    AverageRating = a.Reviews.Any() ? (double?)a.Reviews.Average(r => r.Rating) : null
                })
                .ToListAsync();

            return View(albums);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Info()
        {
            return View();
        }
    }
}
