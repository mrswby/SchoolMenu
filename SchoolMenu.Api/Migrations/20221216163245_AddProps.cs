using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolMenu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Ingredients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuItemIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    MenuItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MenuItemId",
                table: "Ingredients",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_MenuItems_MenuItemId",
                table: "Ingredients",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_MenuItems_MenuItemId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "MenuItemIngredients");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MenuItemId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Ingredients");
        }
    }
}
