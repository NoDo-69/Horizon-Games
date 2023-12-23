using HorizonGames.API.Models;
using Microsoft.EntityFrameworkCore;
namespace HorizonGames.API.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "Metro 2033",
                    Description = "In 2013 the world was devastated by an apocalyptic event, annihilating almost all mankind and turning the Earth's surface into a poisonous wasteland. A handful of survivors took refuge in the depths of the Moscow underground, and human civilization entered a new Dark Age. The year is 2033.",
                    ReleaseDate = new DateTime(2010, 5, 10),
                    Genre = "Sci-Fi Fiction",
                    Developer = "4A Games",
                    Price = 14.99
                },
                new Game
                {
                    Id = 2,
                    Name = "Metro: Last Light",
                    Description = "In 2013 the world was devastated by an apocalyptic event, annihilating almost all mankind and turning the Earth's surface into a poisonous wasteland. A handful of survivors took refuge in the depths of the Moscow underground, and human civilization entered a new Dark Age. The year is 2033.",
                    ReleaseDate = new DateTime(2013, 5, 13),
                    Genre = "Sci-Fi Fiction",
                    Developer = "4A Games",
                    Price = 14.99
                },
                new Game
                {
                    Id = 3,
                    Name = "Metro Exodus",
                    Description = "Flee the shattered ruins of the Moscow Metro and embark on an epic, continent-spanning journey across the post-apocalyptic Russian wilderness. Explore vast, non-linear levels, lose yourself in an immersive, sandbox survival experience, and follow a thrilling story-line.",
                    ReleaseDate = new DateTime(2019, 2, 14),
                    Genre = "Sci-Fi Fiction",
                    Developer = "4A Games",
                    Price = 22.99
                },
                new Game
                {
                    Id = 4,
                    Name = "Dying Light 2 Stay Human",
                    Description = "Dying Light 2 is an action role-playing survival horror video game featuring a zombie apocalyptic-themed open world. Set 22 years after Dying Light, it stars a new protagonist named Aiden Caldwell",
                    ReleaseDate = new DateTime(2022, 2, 4),
                    Genre = "action role-playing survival horror open world Zombies",
                    Developer = "Techland",
                    Price = 39.99
                },
                new Game
                {
                    Id = 5,
                    Name = "Six Days In Fallujah",
                    Description = "Six Days in Fallujah is a realistic first-person tactical shooter based on true stories of Marines, Soldiers, and Iraqi civilians during the toughest urban battle since 1968.",
                    ReleaseDate = new DateTime(2023, 6, 22),
                    Genre = "First-Person Shooter Action",
                    Developer = "Highwire Games",
                    Price = 9.99
                },
                new Game
                {
                    Id = 6,
                    Name = "Sons Of The Forest",
                    Description = "Sent to find a missing billionaire on a remote island, you find yourself in a cannibal-infested hellscape. Craft, build, and struggle to survive, alone or with friends, in this terrifying new open-world survival horror simulator.",
                    ReleaseDate = new DateTime(2023, 2, 23),
                    Genre = "Survival Horror Open World",
                    Developer = "EndLight Games Ltd",
                    Price = 14.99
                },
                new Game
                {
                    Id = 7,
                    Name = "Days Gone",
                    Description = "Ride and fight into a deadly, post pandemic America. Play as Deacon St. John, a drifter and bounty hunter who rides the broken road, fighting to survive while searching for a reason to live in this open-world action-adventure game.",
                    ReleaseDate = new DateTime(2021, 5, 18),
                    Genre = "Open World Zombies Survival Story Rich",
                    Developer = "Bend Studio",
                    Price = 34.99
                },
                new Game
                {
                    Id = 8,
                    Name = "Elden Ring",
                    Description = "THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.",
                    ReleaseDate = new DateTime(2022, 2, 15),
                    Genre = "Open World RPG Dark Fantasy",
                    Developer = "FromSoftware Inc",
                    Price = 39.99
                },
                new Game
                {
                    Id = 9,
                    Name = "Red Dead Redemption 2",
                    Description = "Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.",
                    ReleaseDate = new DateTime(2019, 12, 9),
                    Genre = "Open World Story Rich Adventure",
                    Developer = "Rockstar",
                    Price = 34.99
                },
                new Game
                {
                    Id = 10,
                    Name = "Lethal Company",
                    Description = "A co-op horror about scavenging at abandoned moons to sell scrap to the Company.",
                    ReleaseDate = new DateTime(2023, 10, 24),
                    Genre = "Online Co-op Horror First-Person",
                    Developer = "Zeekerss",
                    Price = 9.99
                },
                new Game
                {
                    Id = 11,
                    Name = "Forza Horizon 5",
                    Description = "Your Ultimate Horizon Adventure awaits! Explore the vibrant open world landscapes of Mexico with limitless, fun driving action in the world’s greatest cars. Conquer the rugged Sierra Nueva in the ultimate Horizon Rally experience. Requires Forza Horizon 5 game, expansion sold separately.",
                    ReleaseDate = new DateTime(2021, 11, 9),
                    Genre = "Racing Open World",
                    Developer = "Playground Games",
                    Price = 34.99
                }
                );
        }
    }
}
