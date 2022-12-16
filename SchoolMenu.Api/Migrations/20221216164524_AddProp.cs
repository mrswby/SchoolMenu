using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMenu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MenuItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MenuItems");
        }
    }
}
