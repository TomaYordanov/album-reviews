using AlbumReviews.Data;
using AlbumReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.Services
{
    public class AlbumService
    {
        private AlbumReviewsContext dbcontext;

        public AlbumService(AlbumReviewsContext dbcontext) 
        { 
            this.dbcontext = dbcontext;
        }
        public async Task<List<Album>> GetAlbumsAsync()
        {
            return await dbcontext.Albums.ToListAsync();
        } 

    }
}
