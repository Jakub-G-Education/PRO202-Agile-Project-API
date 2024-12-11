namespace lightbeam_api.Interfaces;

public interface IWorkshop
{
    int Id { get; set; }
    DateTime? StartDate { get; set; }
    string? Title { get; set; }
    string? Link { get; set; }
    string? StartTime { get; set; }
}