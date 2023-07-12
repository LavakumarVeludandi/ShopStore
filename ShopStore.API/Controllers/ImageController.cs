using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ShopStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImageController
	{
        private readonly ILogger<ImageController> _logger;
        public ImageController(ILogger<ImageController> logger)
		{
            _logger = logger;
		}

        [HttpGet]
        public IActionResult GetDesktopWallpaper()
        {
            string path = @"./Shared/Desktop_Wallpaper.jpg";
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(bytes, "application/octet-stream");
        }

        [HttpGet]
        public IActionResult GetMobileWallpaper()
        {
            string path = @"./Shared/iPhone_Wallpaper.jpg";
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(bytes, "image/jpeg");
        }
    }
}

