namespace HorizonGames.API.Models.DTOS
{
    public class GamesDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre {  get; set; }
        public string? Developer { get; set; }
    }
}
