namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Meal : IMeal
{
    public int Id { get; set; }
    public string? Day { get; set; }
    public string? Food { get; set; }
}