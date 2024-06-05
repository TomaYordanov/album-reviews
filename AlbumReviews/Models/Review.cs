using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumReviews.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        [Range(0, 100)]
        public int Rating { get; set; }
        
        public string ReviewText { get; set; }
        

        public ICollection<Reply> Replies { get; set; }






    }
}
