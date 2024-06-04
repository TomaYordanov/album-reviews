using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumReviews.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public string ReplyText { get; set; }
        [ForeignKey(nameof(Review))]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
       
        







    }
}
