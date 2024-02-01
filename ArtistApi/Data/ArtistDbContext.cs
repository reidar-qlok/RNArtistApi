using ArtistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtistApi.Data
{
    public class ArtistDbContext : DbContext
    {
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options) : base(options)
        {
            
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artists);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Songs)
                .WithOne(s => s.Genres);

            // Seed-metoder
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, ArtistName = "Beatles" },
                new Artist { ArtistId = 2, ArtistName = "Creedense" },
                new Artist { ArtistId = 3, ArtistName = "The Script" },
                new Artist { ArtistId = 4, ArtistName = "McFly" },
                new Artist { ArtistId = 5, ArtistName = "Frank Sinatra" },
                new Artist { ArtistId = 6, ArtistName = "Steve Lacy" }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Pop" },
                new Genre { GenreId = 2, Name = "Rock" },
                new Genre { GenreId = 3, Name = "Jazz" },
                new Genre { GenreId = 4, Name = "Funck" }
                );
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Fortunate song", FK_ArtistId=2, FK_GenreId=1 },
                new Song { SongId = 2, Title = "Let it be", FK_ArtistId = 1, FK_GenreId = 2 },
                new Song { SongId = 3, Title = "All About You", FK_ArtistId = 4, FK_GenreId = 1 },
                new Song { SongId = 4, Title = "Five Colours in Her Hair", FK_ArtistId = 4, FK_GenreId = 1 },
                new Song { SongId = 5, Title = "Breakeven", FK_ArtistId = 3, FK_GenreId = 2 },
                new Song { SongId = 6, Title = "Superheroes", FK_ArtistId = 3, FK_GenreId = 1 },
                new Song { SongId = 7, Title = "My Way", FK_ArtistId = 5, FK_GenreId = 1 },
                new Song { SongId = 8, Title = "Dark Red", FK_ArtistId = 6, FK_GenreId = 3 }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Username = "Admin",DisplayName="Administrator" },
                new User { Username = "Guest", DisplayName = "Guest" }
               );

            // Seeda data för andra entiteter på liknande sätt
        }
    }
}
