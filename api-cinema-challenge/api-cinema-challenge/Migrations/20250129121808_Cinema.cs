using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_cinema_challenge.Migrations
{
    /// <inheritdoc />
    public partial class Cinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    RunTimeMins = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    ScreenNumber = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.UniqueConstraint("AK_Screenings_MovieId_Id", x => new { x.MovieId, x.Id });
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    numSeats = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ScreeningMovieId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.CustomerId, x.ScreeningId });
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Screenings_ScreeningMovieId_ScreeningId",
                        columns: x => new { x.ScreeningMovieId, x.ScreeningId },
                        principalTable: "Screenings",
                        principalColumns: new[] { "MovieId", "Id" });
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(4642), "Emma Scott@icloud.com", "Emma Scott", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(4941) },
                    { 2, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5335), "Anna Thompson@live.se", "Anna Thompson", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5335) },
                    { 3, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5339), "Emma Young@icloud.com", "Emma Young", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5339) },
                    { 4, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5384), "Adrian Hill@outlook.nu", "Adrian Hill", "+46 09 931 3228", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5384) },
                    { 5, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5386), "Frida Scott@hotmail.com", "Frida Scott", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5386) },
                    { 6, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5393), "Johannes Sanchez@hotmail.org", "Johannes Sanchez", "+45 42 342 1293", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5393) },
                    { 7, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5395), "Karl Thompson@live.se", "Karl Thompson", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5395) },
                    { 8, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5397), "Erik Robinson@hotmail.com", "Erik Robinson", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5397) },
                    { 9, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5399), "Johannes Davidsson@live.se", "Johannes Davidsson", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5399) },
                    { 10, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5402), "Sofia Davidsson@google.com", "Sofia Davidsson", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5402) },
                    { 11, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5404), "Frida White@hotmail.org", "Frida White", "+31 07 112 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5404) },
                    { 12, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5405), "Nigel Scott@google.com", "Nigel Scott", "+36 09 939 1218", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5406) },
                    { 13, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5407), "Frida White@hotmail.com", "Frida White", "+31 07 112 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5407) },
                    { 14, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5409), "Sofia Thompson@outlook.nu", "Sofia Thompson", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5409) },
                    { 15, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5410), "Nigel Young@icloud.com", "Nigel Young", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5411) },
                    { 16, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5412), "Anna Robinson@live.se", "Anna Robinson", "+31 07 112 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5412) },
                    { 17, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5414), "Johannes Lewis@hotmail.com", "Johannes Lewis", "+95 13 403 2392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5414) },
                    { 18, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5417), "Adrian Robinson@live.com", "Adrian Robinson", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5417) },
                    { 19, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5418), "Adrian Lewis@hotmail.com", "Adrian Lewis", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5418) },
                    { 20, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5420), "Erik Scott@live.se", "Erik Scott", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5420) },
                    { 21, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5422), "Anna Davidsson@icloud.com", "Anna Davidsson", "+25 65 271 3742", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5422) },
                    { 22, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5424), "Frida Thompson@google.com", "Frida Thompson", "+25 65 271 3742", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5424) },
                    { 23, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5425), "Erik Lewis@google.com", "Erik Lewis", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5426) },
                    { 24, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5427), "Adrian Lewis@outlook.nu", "Adrian Lewis", "+45 45 992 1563", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5427) },
                    { 25, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5429), "Emma White@outlook.nu", "Emma White", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5429) },
                    { 26, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5431), "Sofia Davidsson@icloud.com", "Sofia Davidsson", "+76 13 493 2442", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5431) },
                    { 27, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5432), "Adrian Hill@google.com", "Adrian Hill", "+67 07 292 4392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5432) },
                    { 28, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5434), "Nigel Scott@live.se", "Nigel Scott", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5434) },
                    { 29, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5436), "Sofia Young@outlook.nu", "Sofia Young", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5436) },
                    { 30, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5437), "Sofia Sanchez@hotmail.org", "Sofia Sanchez", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5438) },
                    { 31, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5439), "Karl Lewis@icloud.com", "Karl Lewis", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5439) },
                    { 32, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5453), "Adrian Davidsson@hotmail.com", "Adrian Davidsson", "+76 13 493 2442", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5453) },
                    { 33, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5456), "Karl White@icloud.com", "Karl White", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5456) },
                    { 34, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5458), "Emma Davidsson@live.com", "Emma Davidsson", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5459) },
                    { 35, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5460), "Emma Young@live.se", "Emma Young", "+45 42 342 1293", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5461) },
                    { 36, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5462), "Anna White@google.com", "Anna White", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5462) },
                    { 37, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5464), "Anna Scott@hotmail.com", "Anna Scott", "+67 07 292 4392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5464) },
                    { 38, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5466), "Sofia Thompson@hotmail.org", "Sofia Thompson", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5466) },
                    { 39, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5468), "Nigel Hill@live.com", "Nigel Hill", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5468) },
                    { 40, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5470), "Sofia White@outlook.nu", "Sofia White", "+95 13 403 2392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5470) },
                    { 41, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5472), "Frida White@live.se", "Frida White", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5472) },
                    { 42, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5474), "Erik White@google.com", "Erik White", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5474) },
                    { 43, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5476), "Johannes Hill@icloud.com", "Johannes Hill", "+76 13 493 2442", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5476) },
                    { 44, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5477), "Johannes Young@hotmail.org", "Johannes Young", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5478) },
                    { 45, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5479), "Anna Scott@live.com", "Anna Scott", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5479) },
                    { 46, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5481), "Sofia Davidsson@hotmail.com", "Sofia Davidsson", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5482) },
                    { 47, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5483), "Nigel Hill@live.se", "Nigel Hill", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5483) },
                    { 48, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5485), "Nigel Hill@live.se", "Nigel Hill", "+45 45 992 1563", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5485) },
                    { 49, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5487), "Nigel Sanchez@hotmail.com", "Nigel Sanchez", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5487) },
                    { 50, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5489), "Frida White@live.com", "Frida White", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5489) },
                    { 51, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5491), "Karl Young@live.se", "Karl Young", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5491) },
                    { 52, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5492), "Nigel Sanchez@outlook.nu", "Nigel Sanchez", "+25 65 271 3742", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5493) },
                    { 53, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5494), "Emma Robinson@hotmail.com", "Emma Robinson", "+45 45 992 1563", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5495) },
                    { 54, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5496), "Sofia Lewis@hotmail.com", "Sofia Lewis", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5497) },
                    { 55, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5498), "Sofia Davidsson@icloud.com", "Sofia Davidsson", "+95 13 403 2392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5498) },
                    { 56, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5500), "Sofia Lewis@google.com", "Sofia Lewis", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5500) },
                    { 57, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5502), "Erik Hill@outlook.nu", "Erik Hill", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5502) },
                    { 58, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5504), "Anna Lewis@hotmail.com", "Anna Lewis", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5504) },
                    { 59, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5505), "Johannes White@hotmail.com", "Johannes White", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5506) },
                    { 60, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5507), "Johannes Robinson@google.com", "Johannes Robinson", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5508) },
                    { 61, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5520), "Anna Robinson@hotmail.com", "Anna Robinson", "+45 02 342 0323", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5521) },
                    { 62, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5523), "Johannes Davidsson@hotmail.com", "Johannes Davidsson", "+25 65 271 3742", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5523) },
                    { 63, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5525), "Emma Sanchez@hotmail.com", "Emma Sanchez", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5525) },
                    { 64, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5527), "Karl White@live.com", "Karl White", "+60 57 863 5592", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5527) },
                    { 65, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5528), "Johannes Young@hotmail.com", "Johannes Young", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5529) },
                    { 66, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5532), "Sofia Sanchez@live.se", "Sofia Sanchez", "+45 42 342 1223", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5532) },
                    { 67, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5534), "Sofia Davidsson@google.com", "Sofia Davidsson", "+45 42 342 1293", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5534) },
                    { 68, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5536), "Sofia Young@live.com", "Sofia Young", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5536) },
                    { 69, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5538), "Emma Robinson@live.com", "Emma Robinson", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5538) },
                    { 70, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5540), "Adrian Thompson@google.com", "Adrian Thompson", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5540) },
                    { 71, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5541), "Sofia Young@outlook.nu", "Sofia Young", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5542) },
                    { 72, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5543), "Emma Sanchez@live.com", "Emma Sanchez", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5543) },
                    { 73, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5545), "Erik Hill@hotmail.com", "Erik Hill", "+45 02 342 0323", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5545) },
                    { 74, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5546), "Adrian Young@hotmail.com", "Adrian Young", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5547) },
                    { 75, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5548), "Adrian Robinson@google.com", "Adrian Robinson", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5548) },
                    { 76, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5550), "Erik Lewis@live.se", "Erik Lewis", "+30 07 892 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5550) },
                    { 77, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5552), "Emma Sanchez@live.com", "Emma Sanchez", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5552) },
                    { 78, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5554), "Erik Robinson@hotmail.org", "Erik Robinson", "+23 87 311 3902", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5554) },
                    { 79, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5556), "Frida Thompson@live.com", "Frida Thompson", "+45 42 342 1293", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5556) },
                    { 80, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5558), "Anna Sanchez@hotmail.com", "Anna Sanchez", "+46 09 931 3228", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5559) },
                    { 81, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5560), "Erik Sanchez@hotmail.org", "Erik Sanchez", "+67 07 292 4392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5561) },
                    { 82, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5563), "Frida Robinson@outlook.nu", "Frida Robinson", "+25 65 271 3742", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5563) },
                    { 83, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5565), "Johannes Sanchez@live.com", "Johannes Sanchez", "+45 42 342 1293", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5566) },
                    { 84, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5567), "Sofia Young@outlook.nu", "Sofia Young", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5567) },
                    { 85, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5569), "Johannes Lewis@icloud.com", "Johannes Lewis", "+31 07 112 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5569) },
                    { 86, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5572), "Frida Davidsson@hotmail.org", "Frida Davidsson", "+20 48 271 3712", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5572) },
                    { 87, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5573), "Sofia Sanchez@outlook.nu", "Sofia Sanchez", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5573) },
                    { 88, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5588), "Erik Lewis@live.se", "Erik Lewis", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5588) },
                    { 89, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5590), "Nigel Hill@google.com", "Nigel Hill", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5590) },
                    { 90, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5591), "Karl White@google.com", "Karl White", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5592) },
                    { 91, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5593), "Karl Thompson@live.se", "Karl Thompson", "+45 02 342 0323", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5593) },
                    { 92, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5595), "Nigel Thompson@live.com", "Nigel Thompson", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5595) },
                    { 93, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5597), "Karl Robinson@live.se", "Karl Robinson", "+46 09 221 3788", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5597) },
                    { 94, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5598), "Erik Thompson@hotmail.org", "Erik Thompson", "+31 07 112 5192", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5599) },
                    { 95, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5600), "Erik Hill@icloud.com", "Erik Hill", "+44 09 761 7728", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5600) },
                    { 96, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5602), "Sofia Lewis@live.se", "Sofia Lewis", "+27 13 603 2305", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5602) },
                    { 97, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5603), "Karl Scott@icloud.com", "Karl Scott", "+67 07 292 4392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5604) },
                    { 98, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5605), "Anna Hill@google.com", "Anna Hill", "+45 02 342 0323", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5605) },
                    { 99, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5607), "Erik Lewis@outlook.nu", "Erik Lewis", "+15 13 433 2312", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5607) },
                    { 100, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5608), "Anna Davidsson@live.se", "Anna Davidsson", "+67 07 292 4392", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(5609) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Description", "Rating", "RunTimeMins", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(253), "The movie is about a guy that know another guy and they fight or something", "PG", 99, "The Shawshank Redemption", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(489) },
                    { 2, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(968), "They are in space trying to survive", "G", 95, "The Matrix", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(968) },
                    { 3, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(971), "Small happy people dancing around with a ring", "PG", 73, "The Godfather", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(971) },
                    { 4, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(972), "Superheros that fights villains", "PG-13", 59, "The Lord of the Rings: The Return of the King", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(973) },
                    { 5, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(975), "Horror movie where every person splits up and thinks its a good idea", "PG", 110, "Fight Club", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(975) },
                    { 6, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(983), "The movie is about a guy that know another guy and they fight or something", "G", 128, "The Godfather Part II", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(983) },
                    { 7, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(985), "Horror movie where every person splits up and thinks its a good idea", "PG-13", 144, "The Godfather", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(985) },
                    { 8, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(986), "The movie is about a guy that know another guy and they fight or something", "PG", 146, "Interstellar", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(987) },
                    { 9, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(988), "Superheros that fights villains", "PG", 143, "The Dark Knight", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(988) },
                    { 10, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(990), "They are in space trying to survive", "PG-13", 142, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(991) },
                    { 11, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(992), "Superheros that fights villains", "PG", 112, "Forrest Gump", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(992) },
                    { 12, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(993), "They are in space trying to survive", "PG", 36, "The Godfather", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(993) },
                    { 13, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(995), "The movie is about a guy that know another guy and they fight or something", "PG-13", 32, "The Godfather", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(995) },
                    { 14, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(996), "The greatest movie ever made.", "PG-13", 63, "The Matrix", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(996) },
                    { 15, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(997), "Horror movie where every person splits up and thinks its a good idea", "PG", 99, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(997) },
                    { 16, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(998), "They are in space trying to survive", "PG-13", 85, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(999) },
                    { 17, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1000), "Horror movie where every person splits up and thinks its a good idea", "G", 95, "Inception", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1000) },
                    { 18, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1002), "Superheros that fights villains", "PG", 77, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1002) },
                    { 19, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1003), "The greatest movie ever made.", "PG-13", 132, "The Shawshank Redemption", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1003) },
                    { 20, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1006), "Horror movie where every person splits up and thinks its a good idea", "G", 140, "12 Angry Men", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1006) },
                    { 21, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1007), "Superheros that fights villains", "PG-13", 132, "The Godfather Part II", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1007) },
                    { 22, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1008), "Horror movie where every person splits up and thinks its a good idea", "PG", 82, "The Matrix", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1009) },
                    { 23, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1010), "Superheros that fights villains", "G", 37, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1010) },
                    { 24, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1011), "Horror movie where every person splits up and thinks its a good idea", "G", 78, "The Godfather", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1011) },
                    { 25, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1012), "They are in space trying to survive", "PG-13", 113, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1012) },
                    { 26, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1013), "Horror movie where every person splits up and thinks its a good idea", "PG", 62, "Fight Club", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1014) },
                    { 27, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1015), "The movie is about a guy that know another guy and they fight or something", "G", 81, "The Shawshank Redemption", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1015) },
                    { 28, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1017), "The greatest movie ever made.", "PG", 141, "The Lord of the Rings: The Fellowship of the Ring", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1017) },
                    { 29, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1018), "They are in space trying to survive", "PG-13", 103, "Interstellar", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1018) },
                    { 30, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1019), "Horror movie where every person splits up and thinks its a good idea", "PG-13", 96, "12 Angry Men", new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(1019) }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "Capacity", "CreatedAt", "MovieId", "ScreenNumber", "StartsAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 29, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(8983), 7, 4, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9152) },
                    { 2, 72, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9496), 5, 58, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9496) },
                    { 3, 65, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9498), 25, 42, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9498) },
                    { 4, 51, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9499), 4, 16, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9499) },
                    { 5, 27, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9500), 18, 51, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9501) },
                    { 6, 36, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9506), 12, 10, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9506) },
                    { 7, 36, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9507), 23, 29, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9507) },
                    { 8, 36, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9508), 17, 53, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9509) },
                    { 9, 77, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9509), 28, 24, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9510) },
                    { 10, 73, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9512), 5, 54, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9512) },
                    { 11, 73, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9513), 30, 0, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9513) },
                    { 12, 32, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9514), 4, 51, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9514) },
                    { 13, 64, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9515), 1, 8, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9515) },
                    { 14, 46, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9516), 19, 7, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9517) },
                    { 15, 42, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9518), 4, 11, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9518) },
                    { 16, 73, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9519), 22, 39, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9519) },
                    { 17, 25, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9520), 7, 20, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9520) },
                    { 18, 73, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9522), 23, 46, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9522) },
                    { 19, 50, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9523), 17, 59, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9523) },
                    { 20, 25, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9524), 29, 59, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9524) },
                    { 21, 31, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9525), 8, 7, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9525) },
                    { 22, 55, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9526), 22, 35, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9526) },
                    { 23, 53, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9527), 11, 12, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9528) },
                    { 24, 48, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9529), 24, 58, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9529) },
                    { 25, 21, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9531), 9, 22, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9531) },
                    { 26, 51, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9532), 17, 56, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9532) },
                    { 27, 74, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9533), 8, 55, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9534) },
                    { 28, 35, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9534), 23, 40, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9535) },
                    { 29, 40, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9535), 9, 20, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9536) },
                    { 30, 58, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9537), 15, 48, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9537) },
                    { 31, 42, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9538), 11, 41, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9538) },
                    { 32, 55, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9539), 6, 47, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9539) },
                    { 33, 40, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9540), 17, 14, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9540) },
                    { 34, 23, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9543), 27, 4, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9543) },
                    { 35, 54, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9564), 24, 52, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9564) },
                    { 36, 31, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9565), 16, 21, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9565) },
                    { 37, 20, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9566), 28, 52, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9566) },
                    { 38, 62, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9567), 28, 39, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9567) },
                    { 39, 29, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9568), 13, 2, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9569) },
                    { 40, 48, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9570), 7, 50, new DateTime(2025, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9570) },
                    { 41, 51, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9571), 15, 22, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9571) },
                    { 42, 54, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9572), 27, 3, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9572) },
                    { 43, 74, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9573), 9, 17, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9573) },
                    { 44, 35, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9574), 8, 32, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9574) },
                    { 45, 40, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9575), 4, 15, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9576) },
                    { 46, 22, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9576), 1, 11, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9577) },
                    { 47, 39, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9578), 3, 47, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9578) },
                    { 48, 72, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9579), 3, 59, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9579) },
                    { 49, 48, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9580), 27, 32, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9580) },
                    { 50, 72, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9581), 12, 58, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9581) },
                    { 51, 41, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9582), 18, 47, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9582) },
                    { 52, 61, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9583), 7, 30, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9583) },
                    { 53, 55, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9584), 5, 56, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9584) },
                    { 54, 24, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9585), 19, 21, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9585) },
                    { 55, 26, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9586), 7, 31, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9586) },
                    { 56, 51, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9587), 2, 29, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9588) },
                    { 57, 59, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9588), 22, 14, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9589) },
                    { 58, 36, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9589), 3, 2, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9590) },
                    { 59, 67, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9590), 3, 10, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9591) },
                    { 60, 35, new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9592), 12, 51, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 12, 18, 0, 406, DateTimeKind.Utc).AddTicks(9592) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "CustomerId", "ScreeningId", "CreatedAt", "ScreeningMovieId", "UpdatedAt", "numSeats" },
                values: new object[,]
                {
                    { 1, 44, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(1607), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(1790), 1 },
                    { 2, 20, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2176), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2176), 3 },
                    { 3, 9, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2177), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2177), 3 },
                    { 4, 10, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2178), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2178), 2 },
                    { 5, 50, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2179), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2179), 3 },
                    { 6, 50, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2184), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2184), 7 },
                    { 7, 8, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2185), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2185), 4 },
                    { 8, 18, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2186), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2186), 1 },
                    { 9, 60, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2186), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2187), 6 },
                    { 10, 60, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2188), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2188), 1 },
                    { 11, 9, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2189), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2189), 1 },
                    { 12, 37, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2190), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2190), 3 },
                    { 13, 23, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2190), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2191), 3 },
                    { 14, 41, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2191), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2191), 1 },
                    { 15, 28, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2192), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2192), 5 },
                    { 16, 42, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2192), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2193), 7 },
                    { 17, 43, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2193), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2193), 3 },
                    { 18, 10, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2194), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2195), 5 },
                    { 19, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2195), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2195), 3 },
                    { 20, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2196), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2196), 3 },
                    { 21, 15, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2196), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2197), 3 },
                    { 22, 14, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2197), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2197), 1 },
                    { 23, 17, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2198), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2198), 5 },
                    { 24, 15, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2198), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2199), 1 },
                    { 25, 8, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2199), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2199), 1 },
                    { 26, 47, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2200), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2200), 2 },
                    { 27, 7, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2200), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2201), 2 },
                    { 28, 34, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2201), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2201), 6 },
                    { 29, 55, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2202), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2202), 4 },
                    { 30, 54, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2202), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2202), 4 },
                    { 31, 29, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2203), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2203), 5 },
                    { 32, 7, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2203), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2204), 4 },
                    { 33, 60, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2204), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2204), 7 },
                    { 34, 9, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2206), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2206), 6 },
                    { 35, 20, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2206), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2207), 2 },
                    { 36, 31, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2207), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2207), 7 },
                    { 37, 21, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2208), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2208), 5 },
                    { 38, 30, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2208), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2209), 2 },
                    { 39, 16, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2209), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2209), 1 },
                    { 40, 27, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2210), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2210), 4 },
                    { 41, 38, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2210), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2211), 5 },
                    { 42, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2211), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2212), 6 },
                    { 43, 48, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2213), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2213), 2 },
                    { 44, 29, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2213), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2214), 1 },
                    { 45, 2, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2214), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2214), 5 },
                    { 46, 41, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2215), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2215), 4 },
                    { 47, 53, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2215), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2216), 6 },
                    { 48, 4, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2216), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2216), 3 },
                    { 49, 22, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2217), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2217), 3 },
                    { 50, 57, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2217), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2217), 4 },
                    { 51, 43, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2218), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2218), 7 },
                    { 52, 12, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2218), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2219), 3 },
                    { 53, 8, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2219), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2219), 7 },
                    { 54, 57, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2220), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2220), 7 },
                    { 55, 12, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2220), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2221), 2 },
                    { 56, 50, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2221), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2221), 1 },
                    { 57, 55, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2222), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2222), 4 },
                    { 58, 47, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2222), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2223), 7 },
                    { 59, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2223), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2223), 2 },
                    { 60, 48, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2224), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2224), 3 },
                    { 61, 27, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2224), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2224), 5 },
                    { 62, 3, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2225), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2225), 4 },
                    { 63, 48, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2225), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2226), 2 },
                    { 64, 31, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2226), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2226), 2 },
                    { 65, 25, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2227), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2227), 1 },
                    { 66, 25, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2241), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2242), 7 },
                    { 67, 41, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2242), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2243), 1 },
                    { 68, 37, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2243), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2243), 6 },
                    { 69, 34, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2244), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2244), 4 },
                    { 70, 53, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2244), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2245), 7 },
                    { 71, 19, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2245), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2245), 3 },
                    { 72, 25, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2246), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2246), 7 },
                    { 73, 59, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2246), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2246), 5 },
                    { 74, 26, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2247), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2247), 7 },
                    { 75, 28, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2248), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2248), 3 },
                    { 76, 56, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2248), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2248), 5 },
                    { 77, 38, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2249), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2249), 3 },
                    { 78, 31, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2249), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2250), 1 },
                    { 79, 25, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2250), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2250), 6 },
                    { 80, 46, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2251), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2251), 6 },
                    { 81, 3, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2251), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2252), 2 },
                    { 82, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2252), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2252), 1 },
                    { 83, 29, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2253), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2253), 3 },
                    { 84, 51, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2253), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2253), 1 },
                    { 85, 39, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2254), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2254), 5 },
                    { 86, 59, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2254), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2255), 2 },
                    { 87, 12, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2255), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2255), 1 },
                    { 88, 43, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2256), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2256), 5 },
                    { 89, 5, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2256), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2257), 4 },
                    { 90, 44, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2257), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2257), 7 },
                    { 91, 4, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2258), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2258), 7 },
                    { 92, 39, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2258), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2258), 4 },
                    { 93, 10, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2259), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2259), 1 },
                    { 94, 32, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2260), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2260), 3 },
                    { 95, 30, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2260), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2260), 7 },
                    { 96, 40, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2261), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2261), 4 },
                    { 97, 41, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2261), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2262), 2 },
                    { 98, 18, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2262), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2262), 2 },
                    { 99, 59, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2263), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2263), 6 },
                    { 100, 52, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2263), null, new DateTime(2025, 1, 29, 12, 18, 0, 407, DateTimeKind.Utc).AddTicks(2264), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ScreeningMovieId_ScreeningId",
                table: "Tickets",
                columns: new[] { "ScreeningMovieId", "ScreeningId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
