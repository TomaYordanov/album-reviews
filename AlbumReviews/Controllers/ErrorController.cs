using AlbumReviews.Models;
using AlbumReviews.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumReviews.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return View("Error400");
                case 401:
                    return View("Error401");
                case 403:
                    return View("Error403");
                case 404:
                    return View("Error404");
                default:
                    return View("Error", new ErrorViewModel { StatusCode = statusCode });
            }
        }
    }
}