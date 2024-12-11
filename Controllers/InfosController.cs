namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class InfosController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public InfosController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Info>>> GetAll()
    {
        try
        {
            List<Info> infos = await lightbeamContext.Infos.ToListAsync();
            if (infos.Any())
            {
                return Ok(infos);
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
    public async Task<ActionResult<Info>> GetById(int id)
    {
        try
        {
            Info? infos = await lightbeamContext.Infos.FindAsync(id);
            if (infos != null)
            {
                return Ok(infos);
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

    //Add new info
    [HttpPost]
    public IActionResult Post(Info newInfo)
    {
        if (newInfo == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Infos.Add(newInfo);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    //Update info data
    [HttpPut]
    public async Task<IActionResult> Put(Info updatedInfo)
    {
        if (updatedInfo == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedInfo).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    //Delete info
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Info? infos = await lightbeamContext.Infos.FindAsync(id);
            if (infos != null)
            {
                lightbeamContext.Infos.Remove(infos);
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

