using System.ComponentModel.DataAnnotations;

namespace AlbumReviews.Models
{
    public class Album
    {
        [Key]
       public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
