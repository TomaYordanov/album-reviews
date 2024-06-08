using System.ComponentModel.DataAnnotations;
namespace AlbumReviews.ViewModels
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Rating is required.")]
        [Range(0,100, ErrorMessage = "Rating must be between 0 and 100.")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Review content is required.")]
        [StringLength(800, ErrorMessage = "Review content cannot exceed 800 characters.")]
        public string ReviewContent { get; set; }
        public string UserName { get; set; }


    }
}
