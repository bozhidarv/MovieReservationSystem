using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieReservationSystem.Models;

public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Title { get; set; }
    
    [ForeignKey("Genre")]
    [Column("genre")]
    public long GenreId { get; set; }

    public required string Description { get; set; }
    
    [Required]
    public int Duration { get; set; }
    
    [Required]
    [Column("release_date")]
    public DateTime ReleaseDate { get; set; }
}