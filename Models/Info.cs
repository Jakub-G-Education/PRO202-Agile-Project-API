namespace lightbeam_api.Models;
using lightbeam_api.Interfaces;

public class Info : IInfo
{
    public int Id { get; set; }
    public string? Content { get; set; }
}