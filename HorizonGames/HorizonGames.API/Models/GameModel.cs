using System.ComponentModel.DataAnnotations;

namespace HorizonGames.API.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? Developer { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
