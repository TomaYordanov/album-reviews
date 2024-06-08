using Microsoft.AspNetCore.Mvc;

namespace AlbumReviews.ViewModels
{
    public class AlbumReviewViewModel 
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
