
namespace HorizonGames.API.Models.DTOS
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public double Balance { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
