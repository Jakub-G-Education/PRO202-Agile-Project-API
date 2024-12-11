namespace lightbeam_api.Contexts;

using lightbeam_api.Models;

using Microsoft.EntityFrameworkCore;

public class LightbeamContext : DbContext
{

    public LightbeamContext(DbContextOptions<LightbeamContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Birthday> Birthdays { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Info> Infos { get; set; }
}