using FunctionBasedPlanning.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChinookDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ChinookConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/artists", (ChinookDbContext context) =>
{
    var artists = context.Artists;
    return artists;
})
.WithName("Artists")
.WithOpenApi();

app.MapGet("/tracks", (ChinookDbContext context) =>
{
    var tracks = context.Tracks;
    return tracks;
})
.WithName("Tracks")
.WithOpenApi();

app.Run();
