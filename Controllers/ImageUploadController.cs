namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageUploadController : ControllerBase
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public ImageUploadController(IWebHostEnvironment _webHostEnvironment)
    {
        webHostEnvironment = _webHostEnvironment;
    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult SaveImage(IFormFile file)
    {

        if (file == null)
        {
            return BadRequest();
        }

        try
        {
            string webRootPath = webHostEnvironment.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");

            using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}