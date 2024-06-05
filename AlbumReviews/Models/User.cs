using System.ComponentModel.DataAnnotations;

namespace AlbumReviews.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash {get;set; }
        
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reply> Replies { get; set; }

    }
}
