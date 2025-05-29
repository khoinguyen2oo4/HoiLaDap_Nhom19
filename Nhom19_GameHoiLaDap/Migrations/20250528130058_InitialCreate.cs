using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom19_GameHoiLaDap.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DapAnDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DapAnSai1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DapAnSai2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DapAnSai3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoKho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiChois",
                columns: table => new
                {
                    NguoiChoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiemCaoNhat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiChois", x => x.NguoiChoiId);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    KetQuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiChoiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => x.KetQuaId);
                    table.ForeignKey(
                        name: "FK_KetQuas_NguoiChois_NguoiChoiId",
                        column: x => x.NguoiChoiId,
                        principalTable: "NguoiChois",
                        principalColumn: "NguoiChoiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_NguoiChoiId",
                table: "KetQuas",
                column: "NguoiChoiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauHois");

            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "NguoiChois");
        }
    }
}
