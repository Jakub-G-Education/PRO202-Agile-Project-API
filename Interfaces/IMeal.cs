namespace lightbeam_api.Interfaces;

public interface IMeal
{
    int Id { get; set; }
    string? Day { get; set; }
    string? Food { get; set; }
}