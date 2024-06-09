using AlbumReviews.Data;
using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.Services
{
    public class AlbumService
    {
        private AlbumReviewsContext _context;

        public AlbumService(AlbumReviewsContext _context) 
        { 
            this._context = _context;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await _context.Albums.ToListAsync();
        } 

    }
}
