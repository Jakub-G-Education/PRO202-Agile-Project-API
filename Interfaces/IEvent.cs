namespace lightbeam_api.Interfaces;

public interface IEvent
{
    int Id { get; set; }
    string? Title { get; set; }
    string? Content { get; set; }
    string? Place { get; set; }
    DateTime? Date { get; set; }
    string? Time { get; set; }
}