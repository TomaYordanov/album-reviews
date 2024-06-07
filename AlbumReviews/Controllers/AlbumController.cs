using AlbumReviews.Services;
using AlbumReviews.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumReviews.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumService albumService;
        public async Task<IActionResult> All()
        {
            List<AlbumViewModel> albums =  (await albumService.GetAlbumsAsync()).Select(x => new AlbumViewModel {Title = x.Title, Artist = x.Artist, Genre = x.Genre, Cover = x.Cover, ReleaseDate = x.ReleaseYear}).ToList();   


            return View(albums);
        }
        public AlbumController (AlbumService albumService)
        {
            this.albumService = albumService;
        }
    }
}
