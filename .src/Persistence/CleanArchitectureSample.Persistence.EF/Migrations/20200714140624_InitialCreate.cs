using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitectureSample.Persistence.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TID = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attatchment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Extension = table.Column<string>(maxLength: 10, nullable: true),
                    PackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attatchment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attatchment_Package",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageConfigFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageConfigFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageConfigFile_Package",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerminalPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(nullable: true),
                    PackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminalPackage_Package",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerminalPackage_Terminal",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attatchment_PackageId",
                table: "Attatchment",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageConfigFile_PackageId",
                table: "PackageConfigFile",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalPackage_PackageId",
                table: "TerminalPackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalPackage_TerminalId",
                table: "TerminalPackage",
                column: "TerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attatchment");

            migrationBuilder.DropTable(
                name: "PackageConfigFile");

            migrationBuilder.DropTable(
                name: "TerminalPackage");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Terminal");
        }
    }
}
