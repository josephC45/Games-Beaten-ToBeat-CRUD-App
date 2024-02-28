using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalHoursToBeat = table.Column<int>(type: "int", nullable: false),
                    RemainingHoursToBeat = table.Column<int>(type: "int", nullable: false),
                    GameRating = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    GameCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GameCompleted", "GameRating", "GameTitle", "RemainingHoursToBeat", "TotalHoursToBeat" },
                values: new object[,]
                {
                    { new Guid("00746f8e-afbb-4c59-942e-e981fab339bc"), false, "M", "Rath, Monahan and Hickle", 65, 91 },
                    { new Guid("08b59be3-592a-4704-86f5-99fb6a8959d5"), false, "M", "Hayes and Sons", 66, 2 },
                    { new Guid("4b6bc82e-fcd4-4342-92da-d86536c58bc1"), false, "M", "Upton-Roberts", 79, 62 },
                    { new Guid("4c2ade8f-833b-4a23-be5f-76b0deeba4cd"), true, "M", "Wisoky-Rippin", 63, 77 },
                    { new Guid("51eb6f01-36e9-4667-a4bb-593e10144db5"), false, "M", "Little, Walsh and Kuvalis", 53, 80 },
                    { new Guid("6a3b9dba-e9ff-47f0-83ad-76fe08fbed58"), true, "M", "Schiller-Doyle", 33, 99 },
                    { new Guid("91d7fea5-3860-4f39-9f26-8e7f5fbfa8c9"), true, "M", "Grady-Hilll", 94, 85 },
                    { new Guid("bc56fb1a-1825-48af-8bb3-5bf238084456"), false, "M", "Erdman, Upton and Lynch", 79, 24 },
                    { new Guid("cc064a5b-66f1-4d64-bd20-4d815d5a77af"), true, "M", "Satterfield and Sons", 68, 62 },
                    { new Guid("f64b3a0d-2287-4daf-9f5b-4748f3b76985"), false, "M", "Wisoky, Nikolaus and Nicolas", 62, 83 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
