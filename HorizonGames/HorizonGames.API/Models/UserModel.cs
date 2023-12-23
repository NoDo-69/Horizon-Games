using System.ComponentModel.DataAnnotations;

namespace HorizonGames.API.Models
{
    //0 = Customer
    //1 = Admin

    public enum UserRole
    {
        Customer,
        Admin
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
