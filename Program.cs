using Microsoft.EntityFrameworkCore;
using lightbeam_api.Contexts;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LightbeamContext>(
        options => options.UseSqlite("Data Source=Databases/LightbeamDB.db")
    );

builder.Services.AddCors(
options =>
{
    options.AddPolicy("AllowAll",
    policies => policies
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader()
    );
}
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var provider = new FileExtensionContentTypeProvider();

app.UseCors("AllowAll");

DefaultFilesOptions opt = new();
opt.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(opt);
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();