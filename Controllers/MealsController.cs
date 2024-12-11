namespace lightbeam_api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using lightbeam_api.Models;

[ApiController]
[Route("[controller]")]
public class MealsController : ControllerBase
{
    private readonly LightbeamContext lightbeamContext;

    public MealsController(LightbeamContext _lightbeamContext)
    {
        lightbeamContext = _lightbeamContext;
    }

    // Get All
    [HttpGet]
    public async Task<ActionResult<List<Meal>>> GetAll()
    {
        try
        {
            List<Meal> meals = await lightbeamContext.Meals.ToListAsync();
            if (meals.Any())
            {
                return Ok(meals);
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
    public async Task<ActionResult<Meal>> GetById(int id)
    {
        try
        {
            Meal? meal = await lightbeamContext.Meals.FindAsync(id);
            if (meal != null)
            {
                return Ok(meal);
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

    // Add new meal
    [HttpPost]
    public IActionResult Post(Meal newMeal)
    {
        if (newMeal == null)
        {
            return BadRequest();
        }
        try
        {
            lightbeamContext.Meals.Add(newMeal);
            lightbeamContext.SaveChanges();
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }

    }

    // Update meal data
    [HttpPut]
    public async Task<IActionResult> Put(Meal updatedMeal)

    {
        if (updatedMeal == null)
        {
            return BadRequest();
        }

        try
        {
            
            var existingMeal = await lightbeamContext.Meals.FirstOrDefaultAsync(m => m.Day == updatedMeal.Day);
            if (existingMeal == null)
            {
                return NotFound($"Meal for day {updatedMeal.Day} not found.");
            }

            existingMeal.Food = updatedMeal.Food;

          
            await lightbeamContext.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the meal.");
        }
    }

    // Delete meal
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Meal? meals = await lightbeamContext.Meals.FindAsync(id);
            if (meals != null)
            {
                lightbeamContext.Meals.Remove(meals);
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

