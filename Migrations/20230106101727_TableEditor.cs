using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoWait.Migrations
{
    /// <inheritdoc />
    public partial class TableEditor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "chairCount",
                table: "Table",
                newName: "Y");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Table");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Table",
                newName: "chairCount");
        }
    }
}
