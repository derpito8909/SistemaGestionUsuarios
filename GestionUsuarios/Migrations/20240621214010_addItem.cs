using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUsuarios.Migrations
{
    /// <inheritdoc />
    public partial class addItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "contrasena",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contrasena",
                table: "Usuarios");
        }
    }
}
