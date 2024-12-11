namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Photo : IPhoto
{
    public int Id { get; set; }
    public string? Image { get; set; }
}