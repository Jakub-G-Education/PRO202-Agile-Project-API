namespace lightbeam_api.Interfaces;

public interface IMeeting
{
    int Id { get; set; }
    DateTime? StartDate { get; set; }
    string? Title { get; set; }
    string? StartTime { get; set; }
    string? EndTime { get; set; }

}