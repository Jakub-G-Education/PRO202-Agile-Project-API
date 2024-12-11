namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Birthday : IBirthday
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
}