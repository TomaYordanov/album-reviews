using Microsoft.AspNetCore.Mvc;
using AlbumReviews.Data;
using AlbumReviews.Models;
using AlbumReviews.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using AlbumReviews.ViewModels;

namespace AlbumReviews.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumService _albumService;
        public async Task<IActionResult> All(int pageNumber = 1, int pageSize = 10)
        {
            var albums = await _albumService.GetAlbumsPagedAsync(pageNumber, pageSize);
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
        public AlbumController (AlbumService albumService)
        {
            this._albumService = albumService;
        }
    }
}
