using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace AlbumReviews.Models
{
    public class User : IdentityUser
    {
        
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reply> Replies { get; set; }

    }
}
