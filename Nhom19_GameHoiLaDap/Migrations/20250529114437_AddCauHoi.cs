using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom19_GameHoiLaDap.Migrations
{
    /// <inheritdoc />
    public partial class AddCauHoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CauHois",
                newName: "CauHoiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CauHoiId",
                table: "CauHois",
                newName: "Id");
        }
    }
}
