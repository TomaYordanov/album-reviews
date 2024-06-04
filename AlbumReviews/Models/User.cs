using System.ComponentModel.DataAnnotations;

namespace AlbumReviews.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash {get;set; }
        
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reply> Replies { get; set; }

    }
}
