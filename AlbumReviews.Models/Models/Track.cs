using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumReviews.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }

        public Album Album { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        
    }
}
