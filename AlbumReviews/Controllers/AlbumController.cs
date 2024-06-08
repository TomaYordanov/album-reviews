using AlbumReviews.Services;
using AlbumReviews.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumReviews.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumService _albumService;
        public async Task<IActionResult> All()
        {
            List<AlbumViewModel> albums =  (await _albumService.GetAlbumsAsync()).Select(x => new AlbumViewModel {Title = x.Title, Artist = x.Artist, Genre = x.Genre, Cover = x.Cover, ReleaseDate = x.ReleaseYear, AlbumId = x.AlbumId }).ToList();   


            return View(albums);
        }
        public AlbumController (AlbumService albumService)
        {
            this._albumService = albumService;
        }
    }
}
