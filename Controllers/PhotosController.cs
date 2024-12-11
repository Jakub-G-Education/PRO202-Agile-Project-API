namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public PhotosController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Photo>>> GetAll()
    {
        try
        {
            List<Photo> photos = await lightbeamContext.Photos.ToListAsync();
            if (photos.Any())
            {
                return Ok(photos);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Get By ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Photo>> GetById(int id)
    {
        try
        {
            Photo? photo = await lightbeamContext.Photos.FindAsync(id);
            if (photo != null)
            {
                return Ok(photo);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Add new photo
    [HttpPost]
    public IActionResult Post(Photo newPhoto)
    {
        if (newPhoto == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Photos.Add(newPhoto);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    // Update photo data
    [HttpPut]
    public async Task<IActionResult> Put(Photo updatedPhoto)
    {
        if (updatedPhoto == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedPhoto).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Delete photo
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Photo? photo = await lightbeamContext.Photos.FindAsync(id);
            if (photo != null)
            {
                lightbeamContext.Photos.Remove(photo);
                await lightbeamContext.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
