namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Event : IEvent
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Place { get; set; }
    public DateTime? Date { get; set; }
    public string? Time { get; set; }
}