using System.ComponentModel.DataAnnotations;

namespace AlbumReviews.Models
{
    public class Album
    {
        [Key]
       public int AlbumId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1) ]
        public string Title { get; set; }
        public string Cover { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        [StringLength(50)]
        public string Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
