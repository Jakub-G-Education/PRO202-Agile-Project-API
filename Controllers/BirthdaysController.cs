namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class BirthdaysController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public BirthdaysController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Birthday>>> GetAll()
    {
        try
        {
            List<Birthday> birthdays = await lightbeamContext.Birthdays.ToListAsync();
            if (birthdays.Any())
            {
                return Ok(birthdays);
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
    public async Task<ActionResult<Birthday>> GetById(int id)
    {
        try
        {
            Birthday? birthday = await lightbeamContext.Birthdays.FindAsync(id);
            if (birthday != null)
            {
                return Ok(birthday);
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

    //Add new birthday
    [HttpPost]
    public IActionResult Post(Birthday newBirthday)
    {
        if (newBirthday == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Birthdays.Add(newBirthday);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }


    //Update birthday data
    [HttpPut]
    public async Task<IActionResult> Put(Birthday updatedBirthday)
    {
        if (updatedBirthday == null)
        {
            return BadRequest();
        }

        try
        {
            lightbeamContext.Entry(updatedBirthday).State = EntityState.Modified;
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }


    //Delete birthday
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Birthday? birthday = await lightbeamContext.Birthdays.FindAsync(id);
            if (birthday != null)
            {
                lightbeamContext.Birthdays.Remove(birthday);
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
