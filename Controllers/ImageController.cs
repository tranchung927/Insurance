﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Project3API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            if (_hostingEnvironment != null && _hostingEnvironment.WebRootPath != null)
            {
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, imageName);
                if (System.IO.File.Exists(imagePath))
                {
                    var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                    return File(imageBytes, "image/jpeg");
                }
                else
                {
                    return NotFound(); // Trả về HTTP 404 Not Found nếu tệp ảnh không tồn tại
                }
            }
            else
            {
                return NotFound(); // Trả về HTTP 404 Not Found nếu không tìm thấy đường dẫn web root
            }
        }
    }
}
