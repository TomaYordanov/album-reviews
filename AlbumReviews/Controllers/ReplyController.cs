using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlbumReviews.Data;
using AlbumReviews.Models;
using AlbumReviews.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ReplyController : Controller
{
    private readonly AlbumReviewsContext _context;
    private readonly UserManager<User> _userManager;
    public ReplyController(AlbumReviewsContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReply(int reviewId, string replyContent)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Unauthorized();
        }

        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null)
        {
            return NotFound();
        }

        var reply = new Reply
        {
            ReviewId = reviewId,
            ReplyContent = replyContent,
            UserId = _userManager.GetUserId(User)
        };

        _context.Replies.Add(reply);
        await _context.SaveChangesAsync();

        return RedirectToAction("ViewReplies", new { reviewId });
    }



    public async Task<IActionResult> ViewReplies(int reviewId)
    {
        var replies = await _context.Replies
            .Where(r => r.ReviewId == reviewId)
            .OrderByDescending(r => r.ReplyId)
            .Select(r => new ReplyViewModel
            {
                ReplyId = r.ReplyId,
                ReplyContent = r.ReplyContent,
                UserName = r.User.UserName
            })
            .ToListAsync();
        ViewData["ReviewId"] = reviewId;
        return View(replies);
    }
}
