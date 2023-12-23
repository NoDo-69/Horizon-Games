using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorizonGames.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Developer", "Genre", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "In 2013 the world was devastated by an apocalyptic event, annihilating almost all mankind and turning the Earth's surface into a poisonous wasteland. A handful of survivors took refuge in the depths of the Moscow underground, and human civilization entered a new Dark Age. The year is 2033.", "4A Games", "Sci-Fi Fiction", "Metro 2033", 14.99, new DateTime(2010, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "In 2013 the world was devastated by an apocalyptic event, annihilating almost all mankind and turning the Earth's surface into a poisonous wasteland. A handful of survivors took refuge in the depths of the Moscow underground, and human civilization entered a new Dark Age. The year is 2033.", "4A Games", "Sci-Fi Fiction", "Metro: Last Light", 14.99, new DateTime(2013, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Flee the shattered ruins of the Moscow Metro and embark on an epic, continent-spanning journey across the post-apocalyptic Russian wilderness. Explore vast, non-linear levels, lose yourself in an immersive, sandbox survival experience, and follow a thrilling story-line.", "4A Games", "Sci-Fi Fiction", "Metro Exodus", 22.989999999999998, new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Dying Light 2 is an action role-playing survival horror video game featuring a zombie apocalyptic-themed open world. Set 22 years after Dying Light, it stars a new protagonist named Aiden Caldwell", "Techland", "action role-playing survival horror open world Zombies", "Dying Light 2 Stay Human", 39.990000000000002, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Six Days in Fallujah is a realistic first-person tactical shooter based on true stories of Marines, Soldiers, and Iraqi civilians during the toughest urban battle since 1968.", "Highwire Games", "First-Person Shooter Action", "Six Days In Fallujah", 9.9900000000000002, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Sent to find a missing billionaire on a remote island, you find yourself in a cannibal-infested hellscape. Craft, build, and struggle to survive, alone or with friends, in this terrifying new open-world survival horror simulator.", "EndLight Games Ltd", "Survival Horror Open World", "Sons Of The Forest", 14.99, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Ride and fight into a deadly, post pandemic America. Play as Deacon St. John, a drifter and bounty hunter who rides the broken road, fighting to survive while searching for a reason to live in this open-world action-adventure game.", "Bend Studio", "Open World Zombies Survival Story Rich", "Days Gone", 34.990000000000002, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.", "FromSoftware Inc", "Open World RPG Dark Fantasy", "Elden Ring", 39.990000000000002, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Winner of over 175 Game of the Year Awards and recipient of over 250 perfect scores, RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age. Also includes access to the shared living world of Red Dead Online.", "Rockstar", "Open World Story Rich Adventure", "Red Dead Redemption 2", 34.990000000000002, new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "A co-op horror about scavenging at abandoned moons to sell scrap to the Company.", "Zeekerss", "Online Co-op Horror First-Person", "Lethal Company", 9.9900000000000002, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Your Ultimate Horizon Adventure awaits! Explore the vibrant open world landscapes of Mexico with limitless, fun driving action in the world’s greatest cars. Conquer the rugged Sierra Nueva in the ultimate Horizon Rally experience. Requires Forza Horizon 5 game, expansion sold separately.", "Playground Games", "Racing Open World", "Forza Horizon 5", 34.990000000000002, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
