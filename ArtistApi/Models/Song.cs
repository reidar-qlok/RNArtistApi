using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtistApi.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Title must be 40 characters or less"), MinLength(2)]
        public string Title { get; set; }
        
        public int FK_ArtistId { get; set; }
        [ForeignKey("FK_ArtistId")]
        public Artist Artists { get; set; }
        [ForeignKey("Genres ")]
        public int FK_GenreId { get; set; }
        [ForeignKey("FK_GenreId")]
        public Genre Genres { get; set; }
    }
}
