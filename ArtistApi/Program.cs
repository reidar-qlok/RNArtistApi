using ArtistApi.Data;
using ArtistApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ArtistApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ArtistDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/artists", async (ArtistDbContext context) =>
             await context.Artists.ToListAsync());

            app.MapPost("/artists", async (ArtistDbContext context, Artist artist) =>
            {
                context.Artists.Add(artist);
                await context.SaveChangesAsync();

                return Results.Created($"/artists/{artist.ArtistId}", artist);
            });

            app.MapGet("/songs", async (ArtistDbContext context) =>
            {
                var songs = await context.Songs
                                    .Include(s => s.Artists)
                                    .Include(s => s.Genres)
                                    .ToListAsync();
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                return Results.Json(songs, options);
            });

            app.Run();
        }
    }
}