namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class MeetingsController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public MeetingsController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Meeting>>> GetAll()
    {
        try
        {
            List<Meeting> meetings = await lightbeamContext.Meetings.ToListAsync();
            if (meetings.Any())
            {
                return Ok(meetings);
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
    public async Task<ActionResult<Meeting>> GetById(int id)
    {
        try
        {
            Meeting? meeting = await lightbeamContext.Meetings.FindAsync(id);
            if (meeting != null)
            {
                return Ok(meeting);
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

    // Add new meeting
    [HttpPost]
    public IActionResult Post(Meeting newMeeting)
    {
        if (newMeeting == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Meetings.Add(newMeeting);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    // Update meeting data
    [HttpPut]
    public async Task<IActionResult> Put(Meeting updatedMeeting)
    {
        if (updatedMeeting == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedMeeting).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // Delete meeting
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Meeting? meetings = await lightbeamContext.Meetings.FindAsync(id);
            if (meetings != null)
            {
                lightbeamContext.Meetings.Remove(meetings);
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

