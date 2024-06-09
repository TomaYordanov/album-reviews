using Microsoft.AspNetCore.Mvc;
using AlbumReviews.Data;
using AlbumReviews.Models;
using AlbumReviews.Services;
using System.Linq;
using System.Threading.Tasks;
using AlbumReviews.ViewModels;

namespace AlbumReviews.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumService _albumService;
        public async Task<IActionResult> All(string searchString, string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["TitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["ArtistSortParam"] = sortOrder == "artist" ? "artist_desc" : "artist";

            IQueryable<Album> albumsQuery = _albumService.GetAlbumsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                albumsQuery = albumsQuery.Where(a =>
                    a.Title.Contains(searchString) || a.Artist.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    albumsQuery = albumsQuery.OrderByDescending(a => a.Title);
                    break;
                case "artist":
                    albumsQuery = albumsQuery.OrderBy(a => a.Artist);
                    break;
                case "artist_desc":
                    albumsQuery = albumsQuery.OrderByDescending(a => a.Artist);
                    break;
                default:
                    albumsQuery = albumsQuery.OrderBy(a => a.Title);
                    break;
            }

            var albums = await _albumService.GetAlbumsPagedAsync(albumsQuery, pageNumber, pageSize);

            var albumViewModels = albums.Select(album => new AlbumViewModel
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Artist = album.Artist,
                ReleaseDate = album.ReleaseYear,
                Genre = album.Genre,
                Cover = album.Cover
            }).ToList();

            var paginatedAlbums = new PaginatedList<AlbumViewModel>(albumViewModels, albums.TotalCount, pageNumber, pageSize);

            return View(paginatedAlbums);
        }
        public AlbumController(AlbumService albumService)
        {
            this._albumService = albumService;
        }
    }
}
