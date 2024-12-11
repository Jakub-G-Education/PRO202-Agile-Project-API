namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Workshop : IWorkshop
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? StartTime { get; set; }
}