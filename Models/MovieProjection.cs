using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationSystem.Models;

public class MovieProjection
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [ForeignKey("Movie")]
    public long MovieId { get; set; }
    
    public Movie Movie { get; set; }
    
    [ForeignKey("Theater")]
    public long TheaterId { get; set; }
    
    public Theater Theater { get; set; }
    
    [Required]
    public DateTime StartDateTime { get; set; }
}