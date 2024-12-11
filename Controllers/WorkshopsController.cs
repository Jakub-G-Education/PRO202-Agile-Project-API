namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class WorkshopsController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public WorkshopsController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Workshop>>> GetAll()
    {
        try
        {
            List<Workshop> workshops = await lightbeamContext.Workshops.ToListAsync();
            if (workshops.Any())
            {
                return Ok(workshops);
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
    public async Task<ActionResult<Workshop>> GetById(int id)
    {
        try
        {
            Workshop? workshops = await lightbeamContext.Workshops.FindAsync(id);
            if (workshops != null)
            {
                return Ok(workshops);
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

     // Add new workshop
    [HttpPost]
    public IActionResult Post(Workshop newWorkshop)
    {
        if (newWorkshop == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Workshops.Add(newWorkshop);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    // Update workshop data
    [HttpPut]
    public async Task<IActionResult> Put(Workshop updatedWorkshop)
    {
        if (updatedWorkshop == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedWorkshop).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Delete workshop
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Workshop? workshop = await lightbeamContext.Workshops.FindAsync(id);
            if (workshop != null)
            {
                lightbeamContext.Workshops.Remove(workshop);
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
