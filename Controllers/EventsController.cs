namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public EventsController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetAll()
    {
        try
        {
            List<Event> events = await lightbeamContext.Events.ToListAsync();
            if (events.Any())
            {
                return Ok(events);
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
    public async Task<ActionResult<Event>> GetById(int id)
    {
        try
        {
            Event? events = await lightbeamContext.Events.FindAsync(id);
            if (events != null)
            {
                return Ok(events);
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

    //Add new event
    [HttpPost]
    public IActionResult Post(Event newEvent)
    {
        if (newEvent == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Events.Add(newEvent);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    //Update event data
    [HttpPut]
    public async Task<IActionResult> Put(Event updatedEvent)
    {
        if (updatedEvent == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedEvent).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    //Delete event
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Event? events = await lightbeamContext.Events.FindAsync(id);
            if (events != null)
            {
                lightbeamContext.Events.Remove(events);
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

