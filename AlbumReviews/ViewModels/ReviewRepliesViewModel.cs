using System.Collections.Generic;

namespace AlbumReviews.ViewModels
{
    public class ReviewRepliesViewModel
    {
        public int ReviewId { get; set; }
        public string ReviewContent { get; set; }
        public string UserName { get; set; }
        public List<ReplyViewModel> Replies { get; set; }
    }
}
