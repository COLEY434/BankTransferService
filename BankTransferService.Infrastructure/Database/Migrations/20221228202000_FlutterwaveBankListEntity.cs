using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankTransferService.Infrastructure.Database.Migrations
{
    public partial class FlutterwaveBankListEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlutterwaveBankLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BankCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlutterwaveBankLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlutterwaveBankLists_BankCode",
                table: "FlutterwaveBankLists",
                column: "BankCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlutterwaveBankLists");
        }
    }
}
