namespace lightbeam_api.Interfaces;

public interface IBirthday
{
    int Id { get; set; }
    string? Name { get; set; }
    DateTime? BirthDate { get; set; }
}