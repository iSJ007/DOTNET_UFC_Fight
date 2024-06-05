using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFCFantasyFight.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fighter",
                columns: table => new
                {
                    FighterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldFighterId = table.Column<int>(type: "int", nullable: false),
                    FighterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FighterHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FighterWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FighterReach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FighterStance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FighterDob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FighterSlpm = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    FighterStracc = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    FighterStrdef = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    FighterTdavg = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    FighterTdacc = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    FighterTddef = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    FighterSubavg = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    FighterNick = table.Column<string>(type: "varchar(33)", nullable: false),
                    FighterClass = table.Column<string>(type: "varchar(17)", nullable: false),
                    FighterLoc = table.Column<string>(type: "varchar(40)", nullable: false),
                    FighterCountry = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighter", x => x.FighterId);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    RankingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldRankingId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    FighterId = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.RankingId);
                    table.ForeignKey(
                        name: "FK_Ranking_Fighter_FighterId",
                        column: x => x.FighterId,
                        principalTable: "Fighter",
                        principalColumn: "FighterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_FighterId",
                table: "Ranking",
                column: "FighterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Fighter");
        }
    }
}
